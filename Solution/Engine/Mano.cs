namespace Engine;

public class Mano<T>
{
    public Mano()
    {
        Contenido = new List<IFicha<T>>();
    }
    public List<IFicha<T>> Contenido { get; }

    public int Peso
    {
        get
        {
            int peso = 0;

            foreach (var ficha in Contenido)
            {
                peso += ficha.peso;
            }

            return peso;
        }
    }

    public void Add(IFicha<T> ficha)
    {
        Contenido.Add(ficha);
    }
    public void Remove(IFicha<T> ficha)
    {
        Contenido.Remove(ficha);
    }
}