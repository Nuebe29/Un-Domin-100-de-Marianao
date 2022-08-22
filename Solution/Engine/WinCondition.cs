namespace Engine;

public interface IWincondition<T>
{

    public void Ordena(List<Mano<T>> manos, List<Player<T>> players, Tablero<T> tablero)
    {
        List<Player<T>> copy = new List<Player<T>>();

        foreach (var player in players)
        {
            copy.Add(player);
        }
        int a = manos.Count;
        for (int i = 0; i < a; i++)
        {
            var aux = DecidirGanador(manos, tablero);
            players[i] = copy[aux];
            manos.Remove(manos[aux]);
            copy.Remove(copy[aux]);
        }
    }
    public int DecidirGanador(List<Mano<T>> list, Tablero<T> tablero);

}
public class GanadorCálsico : IWincondition<int>
{
    public int DecidirGanador(List<Mano<int>> list, Tablero<int> tablero)
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
public class GanadorPorFichas : IWincondition<int>
{
    public int DecidirGanador(List<Mano<int>> list, Tablero<int> tablero)
    {
        int aux = int.MaxValue;
        int devolver = 0;
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].Contenido.Count < aux) { aux = list[i].Contenido.Count(); devolver = i; }
        }
        return devolver;
    }
}
public class GanadorPorPases : IWincondition<int>
{
    public int DecidirGanador(List<Mano<int>> list, Tablero<int> tablero)
    {
        int devolver = 0;
        int count = int.MaxValue;
        for (int i = 0; i < list.Count; i++)
        {
            int aux = 0;
            foreach (Tablero<int> nodo in tablero)
            {
                if (nodo.Hoja.Player==i  && nodo.Hoja.Ficha is null) aux++;
            }
            if(aux<count){
                count = aux;
                devolver = i;
            }
        }
        return devolver;
    }
}
