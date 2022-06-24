namespace Engine;

public class Mano<IFicha>
{
    public Mano()
    {
        Contenido = new List<IFicha>();
    }
    public List<IFicha> Contenido { get; }

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

    public void Add(IFicha ficha)
    {
        Contenido.Add(ficha);
    }
    public void Remove(IFicha ficha)
    {
        Contenido.Remove(ficha);
    }
}