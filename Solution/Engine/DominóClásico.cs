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

public class Nodo<T>
{
    public Nodo(T entrada, int turno)
    {
        Entrada = entrada;
        Turno = turno;
        Jugabilidad = true;
    }
    
    public T Entrada { get; set; }
    public int Turno { get; }
    public bool Jugabilidad { get; set; }
}

public interface ITablero<T> : IEnumerable<Nodo<T>>
{
    public  Nodo<T> Hoja { get; }
    public List<TableroClásico> Ramas { get; }

}
public class TableroClásico : ITablero<int>
{
    public TableroClásico(int entrada, int turno)
    {
        Hoja = new Nodo<int>(entrada,turno);
        Ramas = new List<TableroClásico>();
    }

    public  Nodo<int> Hoja { get; }
    public List<TableroClásico> Ramas { get; }


    IEnumerator<Nodo<int>> IEnumerable<Nodo<int>>.GetEnumerator()
    {
        yield return Hoja;

        foreach (var hijo in Ramas)
        {
            foreach (Nodo<int> item in hijo)
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





public static class Leyes
{
    public static bool EsJugable(FichaClásica ficha, TableroClásico tablero)
    {
        return ficha.Cara1 == tablero.Hoja.Entrada || ficha.Cara2 == tablero.Hoja.Entrada;
    }
    
    public static bool EsJugable(FichaClásica ficha, int entrada)
    {
        return ficha.cara1 == entrada || ficha.cara2 == entrada;
    }

    public static bool EsJugable(Mano<int> mano, TableroClásico tablero)
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
            tablero.Ramas.Add(new TableroClásico(ficha.Cara1, tablero.Hoja.Turno+1));
            tablero.Ramas.Add(new TableroClásico(ficha.Cara2, tablero.Hoja.Turno+1));
            tablero.Hoja.Jugabilidad = false;
        }
        
        else if (Leyes.EsJugable(ficha, tablero))
        {
            int e = ficha.Cara1 == tablero.Hoja.Entrada ? ficha.Cara2 : ficha.Cara1;
            tablero.Ramas.Add(new TableroClásico(e, tablero.Hoja.Turno+1));
            tablero.Hoja.Jugabilidad = false;
        }
        
        

        else throw new Exception("Esa Jugada no es posible");
    }

    
}



