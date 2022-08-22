﻿using System.Collections;

namespace Engine;
public class Nodo<T>
{
    public Nodo()
    {
        Turno = -1;
        Jugabilidad = true;
    }

    public Nodo(T entrada, int turno, Ficha<T> ficha, int player)
    {
        Entrada = entrada;
        Turno = turno;
        Jugabilidad = true;
        Ficha = ficha;
        Player = player;
    }
    
    public T Entrada { get; set; }
    public int Turno { get; }
    public bool Jugabilidad { get; set; }
    public bool Salida{get;set;}
    public Ficha<T> Ficha;
    public int Player;

    
}
public class Tablero<T> : IEnumerable<Tablero<T>>
{
    public Tablero(T entrada, int turno, Ficha<T> ficha, int player)
    {
        Hoja = new Nodo<T>(entrada,turno,ficha, player);
        Ramas = new List<Tablero<T>>();
    }

    public Tablero()
    {
        Ramas = new List<Tablero<T>>();
        Hoja = new Nodo<T>();
    }
    

    public  Nodo<T> Hoja { get; }
    public List<Tablero<T>> Ramas { get; }
    

    IEnumerator<Tablero<T>> IEnumerable<Tablero<T>>.GetEnumerator()
    {
        yield return this;

        foreach (var hijo in Ramas)
        {
            foreach (Tablero<T> item in hijo)
            {
                yield return item;
            }
        }
    }

     public IEnumerator GetEnumerator()
    {
        yield return this;

        foreach (var hijo in Ramas)
        {
            foreach (Tablero<T> item in hijo)
            {
                yield return item;
            }
        }
    }
}

