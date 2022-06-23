using System.Collections;

namespace Engine;

public class FichaClásica
{
    public FichaClásica(int cara1, int cara2)
    {
        Cara1 = cara1;
        Cara2 = cara2;
    }

    public int Cara1 { get; }
    
    public int Cara2 { get; }
    
    public int Peso => Cara1 + Cara2;

    public override string ToString()
    {
        return $"[{Cara1},{Cara2}]";
    }
}

public class Nodo
{
    public Nodo()
    {
        Entrada = -1;
        Jugabilidad = true;
    }
    
    public int Entrada { get; set; }
    
    public bool Jugabilidad { get; set; }
}
public class TableroClásico : IEnumerable<Nodo>
{
    public TableroClásico()
    {
        Hoja = new Nodo();
        Ramas = new List<TableroClásico>();
    }

    public  Nodo Hoja { get; }
    public List<TableroClásico> Ramas { get; }


    IEnumerator<Nodo> IEnumerable<Nodo>.GetEnumerator()
    {
        yield return Hoja;

        foreach (var hijo in Ramas)
        {
            foreach (Nodo item in hijo)
            {
                yield return item;
            }
        }
    }

    public IEnumerator GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class Mano
{
    public Mano()
    {
        Contenido = new List<FichaClásica>();
    }
    public List<FichaClásica> Contenido { get; }

    public int Peso
    {
        get
        {
            int peso = 0;

            foreach (var ficha in Contenido)
            {
                peso += ficha.Peso;
            }

            return peso;
        }
    }

    public void Add(FichaClásica ficha)
    {
        Contenido.Add(ficha);
    }
    public void Remuve(FichaClásica ficha)
    {
        Contenido.Remove(ficha);
    }
}

public static class Leyes
{
    public static bool EsJugable(FichaClásica ficha, TableroClásico tablero)
    {
        return ficha.Cara1 == tablero.Hoja.Entrada || ficha.Cara2 == tablero.Hoja.Entrada;
    }
    

    public static bool EsJugable(Mano mano, TableroClásico tablero)
    {
        foreach (var ficha in mano.Contenido)
        {
            if (EsJugable(ficha, tablero)) return true;
        }

        return false;
    }
}

public class JugadorRandom
{
    public JugadorRandom(string name)
    {
        Name = name;
    }
    public string Name { get; }
    
    public FichaClásica Jugada(List<FichaClásica> mano, TableroClásico tablero)
    {
        List<FichaClásica> fichasJugables = new List<FichaClásica>();
        
        foreach (var ficha in mano)
        {
            if (Leyes.EsJugable(ficha, tablero)) fichasJugables.Add(ficha);
        }

        Random random = new Random();
        return fichasJugables[random.Next(fichasJugables.Count)];
    }

    public FichaClásica Salida(List<FichaClásica> mano)
    {
        Random random = new Random();
        int n = random.Next(mano.Count);
        return mano[n];
    }
}

public static class JuegoClásico
{
    public static void Colocar(FichaClásica ficha, TableroClásico tablero)
    {
        if (tablero.Hoja.Entrada == -1)
        {
            tablero.Ramas.Add(new TableroClásico());
            tablero.Ramas.Add(new TableroClásico());
            tablero.Ramas[0].Hoja.Entrada = ficha.Cara1;
            tablero.Ramas[1].Hoja.Entrada = ficha.Cara2;
        }
        
        else if (Leyes.EsJugable(ficha, tablero))
        {
            tablero.Ramas.Add(new TableroClásico());
            tablero.Ramas[0].Hoja.Entrada = ficha.Cara1 == tablero.Hoja.Entrada ? ficha.Cara2 : ficha.Cara1;
        }
        
        

        else throw new Exception("Esa Jugada no es posible");
    }

    public static JugadorRandom DecidirGanador(List<JugadorRandom> jugadores, List<Mano> manos)
    {
        JugadorRandom ganador = new JugadorRandom("nadie");
        int min = int.MaxValue;

        for (int i = 0; i < jugadores.Count; i++)
        {
            if (manos[i].Peso < min)
            {
                ganador = jugadores[i];
                min = manos[i].Peso;
            }
        }

        return ganador;
    }
}

public static class Generador
{
    public static List<FichaClásica> Genera(int n)
    {
        List<FichaClásica> fichas = new List<FichaClásica>();

        for (int i = 0; i <= n; i++)
        {
            for (int j = i; j <= n; j++)
            {
                fichas.Add(new FichaClásica(i,j));
            }
        }

        return fichas;
    }
}

public static class Repartidor
{
    public static void Reparte(List<FichaClásica> mazo, int c, List<Mano> manos)
    {
        if (mazo.Count < c * manos.Count)
        {
            throw new Exception("No es posible repartir");
        }

        else
        {
            Random r = new Random();

            foreach (var mano in manos)
            {
                for (int i = 0; i < c; i++)
                {
                    int n = r.Next(mazo.Count);
                    mano.Contenido.Add(mazo[n]);
                    mazo.Remove(mazo[n]);
                }
            }
        }
    }
}