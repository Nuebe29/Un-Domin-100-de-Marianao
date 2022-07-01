using System.Collections;

namespace Engine;
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

public interface ITablero<T> : IEnumerable<ITablero<T>>
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


    IEnumerator<ITablero<int>> IEnumerable<ITablero<int>>.GetEnumerator()
    {
        yield return this;

        foreach (var hijo in Ramas)
        {
            foreach (TableroClásico item in hijo)
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