using System.Collections;

namespace Engine;

public interface ITablero<T> : IEnumerable<Nodo<T>>
{
    public  Nodo<T> Hoja { get; }
    public List<TableroClásico> Ramas { get; }

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