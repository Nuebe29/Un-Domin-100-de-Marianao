namespace Engine;

public interface IWincondition<T>
{
    public int DecidirGanador(List<Mano<T>> list);
}
<<<<<<< HEAD
public class ganadorclsico : IWincondition<int>
=======
public class GanadorCálsico : IWincondition<int>
>>>>>>> 0fbaf73d60127f9bca9bb720a32eddcf6a5a070a
{
    public int DecidirGanador(List<Mano<int>> list)
    {
        int ganador = 0;
        int min = int.MaxValue;
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].Contenido.Count == 0) return i;
            if (list[i].Peso < min)
            {
                ganador = i;
                min = list[i].Peso;
            }
            

        }
        return ganador;
    }
}