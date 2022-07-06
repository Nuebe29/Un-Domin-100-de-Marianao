namespace Engine;

public interface IWincondition<T>
{
    public int DecidirGanador(List<Mano<T>> list);
}
public class GanadorCálsico : IWincondition<int>
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
public class GanadorMultiplosx5 : IWincondition<int>

{
    public List<int> Puntos{get; set;}
    public int DecidirGanador(List<Mano<int>> list)
    {
        int ganador = 0;
        int max = 0;
        for(int i = 0; i< Puntos.Count;i++){
            if(Puntos[i]>max){
                max = Puntos[i];
                ganador=i;
            }
        }
        return ganador;
    }
}
