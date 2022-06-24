namespace Engine;
public interface IDealer<T>{
    public List<Mano<T>> Reparte(List<T> mazo, int jugadores, int cant);
}
public class DealerClasico : IDealer<IFicha<int>>
{
    public List<Mano<IFicha<int>>> Reparte(List<IFicha<int>> mazo, int jugadores, int cant)
    {
        Random r = new Random();
        List<Mano<IFicha<int>>> list = new List<Mano<IFicha<int>>>();
        for(int i = 0; i< jugadores;i++){
            list.Add(new Mano<IFicha<int>>());
        }
        for(int i = 0; i< jugadores;i++){
            for(int j = 0;j<cant;j++){
                list[i].Contenido.Add(mazo[r.Next(mazo.Count)]);
                mazo.Remove(mazo[r.Next(mazo.Count)]);
            }
        }
        return list;
    }
}
