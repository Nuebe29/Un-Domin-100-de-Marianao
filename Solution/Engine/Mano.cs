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
<<<<<<< HEAD
                peso += ficha.peso;
=======
                peso += ficha.Peso;
>>>>>>> 0fbaf73d60127f9bca9bb720a32eddcf6a5a070a
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