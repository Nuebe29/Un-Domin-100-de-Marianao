namespace Engine;

public interface IReferee<T>{
    public List<Movimiento<int>> SacarJugadas(TableroClásico tablero, List<Mano<T>> manos, int i);
    public void EfectuarJugada(Movimiento<T> jugada, TableroClásico tablero, List<Mano<T>> manos, int i);
}
public class RefereeClásico:IReferee<int>
{
    public RefereeClásico(IMatcher<int> matcher)
    {
        Matcher = matcher;
        Pases = 0;
    }
    public int Pases { get; set; }

    private IMatcher<int> Matcher;

    public List<Movimiento<int>> SacarJugadas(TableroClásico tablero, List<Mano<int>> manos, int i)
    {
        List<Movimiento<int>> jugadas = new List<Movimiento<int>>();

        foreach (TableroClásico t in tablero)
        {
            if (t.Hoja.Jugabilidad)
            {
                foreach (var ficha in manos[i].Contenido)
                {
                    if (Matcher.matchea(ficha, t.Hoja))
                    {
                        jugadas.Add(new Movimiento<int>(ficha, t.Hoja, false));
                    }
                }
            }
        }

        if (jugadas.Count == 0) jugadas.Add(new Movimiento<int>(default!, default!, true));

        return jugadas;
    }

    public void EfectuarJugada(Movimiento<int> jugada, TableroClásico tablero, List<Mano<int>> manos, int i)
    {
        if (!jugada.EsPase)
        {
            Pases = 0;
            manos[i].Remove(jugada.Ficha);
            foreach (TableroClásico t in tablero)
            {
                if (t.Hoja == jugada.Nodo)
                {
                    if (jugada.Nodo.Entrada == -1)
                    {
                        t.Ramas.Add(new TableroClásico(jugada.Ficha.Cara2, 1));
                        t.Ramas.Add(new TableroClásico(jugada.Ficha.Cara1, 1));
                    }
                    else if (jugada.Ficha.Cara1 == t.Hoja.Entrada)
                    {
                        t.Ramas.Add(new TableroClásico(jugada.Ficha.Cara2, 1));
                    }
                    else
                    {
                        t.Ramas.Add(new TableroClásico(jugada.Ficha.Cara1, 1));
                    }
                    t.Hoja.Jugabilidad = false;

                }
            }

        }

        else Pases++;
    }

}
public class RefereeLongana


{
    public RefereeLongana(IMatcher<int> matcher)
    {
        Matcher = matcher;
        Pases = 0;
    }
    public int Pases { get; set; }

    private IMatcher<int> Matcher;

    public List<Movimiento<int>> SacarJugadas(TableroClásico tablero, List<Mano<int>> manos, int i)
    {
        List<Movimiento<int>> jugadas = new List<Movimiento<int>>();
        if (tablero.Ramas.Count != 0)
        {
            foreach (TableroClásico t in tablero.Ramas[i]) { if (t.Ramas.Count == 0) t.Hoja.Jugabilidad = true; }
        }
        foreach (TableroClásico t in tablero)
        {
            if (t.Hoja.Jugabilidad)
            {
                foreach (var ficha in manos[i].Contenido)
                {
                    if (Matcher.matchea(ficha, t.Hoja))
                    {
                        jugadas.Add(new Movimiento<int>(ficha, t.Hoja, false));
                    }
                }
            }
        }

        if (jugadas.Count == 0) jugadas.Add(new Movimiento<int>(default!, default!, true));

        return jugadas;
    }

    public void EfectuarJugada(Movimiento<int> jugada, TableroClásico tablero, List<Mano<int>> manos, int i)
    {
        if (!jugada.EsPase)
        {
            Pases = 0;
            manos[i].Remove(jugada.Ficha);
            foreach (TableroClásico t in tablero)
            {
                if (t.Hoja == jugada.Nodo)
                {
                    if (jugada.Nodo.Entrada == -1)
                    {
                        foreach (var mano in manos)
                        {
                            t.Ramas.Add(new TableroClásico(jugada.Ficha.Cara1, 1));
                        }
                        foreach (TableroClásico rama in t.Ramas)
                        {
                            rama.Hoja.Jugabilidad = false;
                        }
                    }
                    else if (Matcher.matchea(jugada.Nodo.Entrada, jugada.Ficha.Cara1))
                    {
                        t.Ramas.Add(new TableroClásico(jugada.Ficha.Cara2, 1));
                    }
                    else
                    {
                        t.Ramas.Add(new TableroClásico(jugada.Ficha.Cara1, 1));
                    }
                    t.Hoja.Jugabilidad = false;
                    

                }
            }
            if (jugada.Nodo.Entrada != -1){
            foreach (TableroClásico t in tablero.Ramas[i])
                    {
                        if (t.Ramas.Count > 0) t.Ramas[0].Hoja.Jugabilidad = false;
                    }
            }

        }

        else
        {
            Pases++;

        }
    }

}
public class RefereeLonganax5{
    public RefereeLonganax5(IMatcher<int> matcher)
    {
        
        Puntos= new List<int>();
        Matcher = matcher;
        Pases = 0;
    }
    public List<int> Puntos{get; }
    public int Pases { get; set; }

    private IMatcher<int> Matcher;

    public List<Movimiento<int>> SacarJugadas(TableroClásico tablero, List<Mano<int>> manos, int i)
    {
        List<Movimiento<int>> jugadas = new List<Movimiento<int>>();
        if (tablero.Ramas.Count != 0)
        {
            foreach (TableroClásico t in tablero.Ramas[i]) { if (t.Ramas.Count == 0) t.Hoja.Jugabilidad = true; }
        }
        foreach (TableroClásico t in tablero)
        {
            if (t.Hoja.Jugabilidad)
            {
                foreach (var ficha in manos[i].Contenido)
                {
                    if (Matcher.matchea(ficha, t.Hoja))
                    {
                        jugadas.Add(new Movimiento<int>(ficha, t.Hoja, false));
                    }
                }
            }
        }

        if (jugadas.Count == 0) jugadas.Add(new Movimiento<int>(default!, default!, true));

        return jugadas;
    }

    public void EfectuarJugada(Movimiento<int> jugada, TableroClásico tablero, List<Mano<int>> manos, int i)
    {
        if (!jugada.EsPase)
        {
            Pases = 0;
            int posiblespuntos = 0;
            manos[i].Remove(jugada.Ficha);
            foreach (TableroClásico t in tablero)
            {
                if (t.Hoja == jugada.Nodo)
                {
                    if (jugada.Nodo.Entrada == -1)
                    {
                        foreach (var mano in manos)
                        {
                            t.Ramas.Add(new TableroClásico(jugada.Ficha.Cara1, 1));
                            Puntos.Add(0);
                        }
                        foreach (TableroClásico rama in t.Ramas)
                        {
                            rama.Hoja.Jugabilidad = false;
                        }
                    }
                    else if (Matcher.matchea(jugada.Nodo.Entrada, jugada.Ficha.Cara1))
                    {
                        t.Ramas.Add(new TableroClásico(jugada.Ficha.Cara2, 1));
                    }
                    else
                    {
                        t.Ramas.Add(new TableroClásico(jugada.Ficha.Cara1, 1));
                    }
                    t.Hoja.Jugabilidad = false;
                    

                }
            }
            if (jugada.Nodo.Entrada != -1){
            foreach (TableroClásico t in tablero.Ramas[i])
                    {
                        if (t.Ramas.Count > 0) t.Ramas[0].Hoja.Jugabilidad = false;
                    }
            }
            foreach(TableroClásico t in tablero){
                if(t.Ramas.Count==0)posiblespuntos+=t.Hoja.Entrada;
            }
            if(posiblespuntos%5==0)Puntos[i]+=posiblespuntos;


        }

        else
        {
            Pases++;

        }
    }
}
public class RefereeClásicox5{
    public RefereeClásicox5(IMatcher<int> matcher)
    {
        Puntos = new List<int>();
        Matcher = matcher;
        Pases = 0;
    }
    public int Pases { get; set; }
    public List<int> Puntos{get; }

    private IMatcher<int> Matcher;

    public List<Movimiento<int>> SacarJugadas(TableroClásico tablero, List<Mano<int>> manos, int i)
    {
        List<Movimiento<int>> jugadas = new List<Movimiento<int>>();

        foreach (TableroClásico t in tablero)
        {
            if (t.Hoja.Jugabilidad)
            {
                foreach (var ficha in manos[i].Contenido)
                {
                    if (Matcher.matchea(ficha, t.Hoja))
                    {
                        jugadas.Add(new Movimiento<int>(ficha, t.Hoja, false));
                    }
                }
            }
        }

        if (jugadas.Count == 0) jugadas.Add(new Movimiento<int>(default!, default!, true));

        return jugadas;
    }

    public void EfectuarJugada(Movimiento<int> jugada, TableroClásico tablero, List<Mano<int>> manos, int i)
    {
        if (!jugada.EsPase)
        {
            Pases = 0;
            int posiblespuntos = 0;
            manos[i].Remove(jugada.Ficha);
            foreach (TableroClásico t in tablero)
            {
                if (t.Hoja == jugada.Nodo)
                {
                    if (jugada.Nodo.Entrada == -1)
                    {
                        t.Ramas.Add(new TableroClásico(jugada.Ficha.Cara2, 1));
                        t.Ramas.Add(new TableroClásico(jugada.Ficha.Cara1, 1));
                        foreach(var mano in manos){
                            Puntos.Add(0);
                        }
                    }
                    else if (jugada.Ficha.Cara1 == t.Hoja.Entrada)
                    {
                        t.Ramas.Add(new TableroClásico(jugada.Ficha.Cara2, 1));
                    }
                    else
                    {
                        t.Ramas.Add(new TableroClásico(jugada.Ficha.Cara1, 1));
                    }
                    t.Hoja.Jugabilidad = false;

                }
            }
            foreach(TableroClásico t in tablero){
                if(t.Ramas.Count==0)posiblespuntos+=t.Hoja.Entrada;
            }
            if(posiblespuntos%5==0)Puntos[i]+=posiblespuntos;

        }

        else Pases++;
    }
}