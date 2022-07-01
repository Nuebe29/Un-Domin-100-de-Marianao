﻿namespace Engine;

public class RefereeClásico
{
    public RefereeClásico(IMatcher<int> matcher)
    {
        Matcher = matcher;
        Pases = 0;
    }
    public int Pases{get ; set;}

    private IMatcher<int> Matcher;

    public List<Movimiento<int>> SacarJugadas(TableroClásico tablero, Mano<int> mano)
    {
        List<Movimiento<int>> jugadas = new List<Movimiento<int>>();

        foreach (TableroClásico t in tablero)
        {
            if (t.Hoja.Jugabilidad)
            {
                foreach (var ficha in mano.Contenido)
                {
                    if (Matcher.matchea(ficha, t.Hoja))
                    {
                        jugadas.Add(new Movimiento<int>(ficha, t.Hoja, false));
                    }
                }
            }
        }
        
        if(jugadas.Count == 0) jugadas.Add(new Movimiento<int>(default!, default!, true));

        return jugadas;
    }

    public void EfectuarJugada(Movimiento<int> jugada, TableroClásico tablero, Mano<int> mano)
    {
        if (!jugada.EsPase)
        {
            Pases = 0;
            mano.Remove(jugada.Ficha);

            foreach (TableroClásico t in tablero)
            {
                if (t.Hoja == jugada.Nodo)
                {   
                    if(jugada.Nodo.Entrada==-1 ){
                        t.Ramas.Add(new TableroClásico(jugada.Ficha.Cara2, 1));
                        t.Ramas.Add(new TableroClásico(jugada.Ficha.Cara1, 1));
                        t.Hoja.Jugabilidad = false;
                    }
                    else if (jugada.Ficha.Cara1 == t.Hoja.Entrada)
                    {
                        t.Hoja.Jugabilidad = false;
                        t.Ramas.Add(new TableroClásico(jugada.Ficha.Cara2, 1));
                    }
                    else
                    {
                        t.Hoja.Jugabilidad = false;
                        t.Ramas.Add(new TableroClásico(jugada.Ficha.Cara1, 1)); 
                    }
                }
            }
        }
        else Pases++;
    }

}