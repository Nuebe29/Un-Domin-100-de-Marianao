namespace Engine;

public interface IWincondition<T>
{
    public int DecidirGanador(List<Mano<IFicha<T>>> list);
}
public class ganadorclsico : IWincondition<int>
{
    public int DecidirGanador(List<Mano<IFicha<int>>> list)
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