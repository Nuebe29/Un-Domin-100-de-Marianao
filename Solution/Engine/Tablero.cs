<<<<<<< HEAD
using System.Collections;

namespace Engine;
=======
﻿using System.Collections;

namespace Engine;

public interface ITablero<T> : IEnumerable<Nodo<T>>
{
    public  Nodo<T> Hoja { get; }
    public List<TableroClásico> Ramas { get; }

}

>>>>>>> 0fbaf73d60127f9bca9bb720a32eddcf6a5a070a
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

<<<<<<< HEAD
public interface ITablero<T> : IEnumerable<Nodo<T>>
{
    public  Nodo<T> Hoja { get; }
    public List<TableroClásico> Ramas { get; }

}
=======
>>>>>>> 0fbaf73d60127f9bca9bb720a32eddcf6a5a070a
public class TableroClásico : ITablero<int>
{
    public TableroClásico(int entrada, int turno)
    {
        Hoja = new Nodo<int>(entrada,turno);
        Ramas = new List<TableroClásico>();
    }

    public  Nodo<int> Hoja { get; }
    public List<TableroClásico> Ramas { get; }


<<<<<<< HEAD
    

    public IEnumerator<Nodo<int>> GetEnumerator()
    {
        return GetEnumerator();
    }

=======
>>>>>>> 0fbaf73d60127f9bca9bb720a32eddcf6a5a070a
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
<<<<<<< HEAD
=======

    public IEnumerator GetEnumerator()
    {
        return GetEnumerator();
    }
>>>>>>> 0fbaf73d60127f9bca9bb720a32eddcf6a5a070a
}