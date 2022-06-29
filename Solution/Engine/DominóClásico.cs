namespace Engine;

public static class Leyes
{
    public static bool EsJugable(FichaClásica ficha, TableroClásico tablero)
    {
        return EsJugable(ficha, tablero.Entrada1) || EsJugable(ficha, tablero.Entrada2);
    }
    
    public static bool EsJugable(FichaClásica ficha, int entrada)
    {
        return ficha.cara1 == entrada || ficha.cara2 == entrada;
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
        if (tablero.Contenido.Count == 0)
        {
            tablero.Contenido.Add(ficha);
            tablero.Entrada1 = ficha.cara1;
            tablero.Entrada2 = ficha.cara2;
        }
        
        else if (Leyes.EsJugable(ficha, tablero.Entrada1))
        {
            tablero.Contenido.Add(ficha);
            tablero.Entrada1 = ficha.cara1 == tablero.Entrada1 ? ficha.cara2 : ficha.cara1;
        }
        
        else if (Leyes.EsJugable(ficha, tablero.Entrada2))
        {
            tablero.Contenido.Add(ficha);
            tablero.Entrada2 = ficha.cara1 == tablero.Entrada2 ? ficha.cara2 : ficha.cara1;
        }

        else throw new Exception("Esa Jugada no es posible");
    }

    
}



