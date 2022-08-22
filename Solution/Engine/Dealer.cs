namespace Engine;
public interface IDealer<T>{
    public List<Mano<T>> Reparte(List<Ficha<T>> mazo, int jugadores, int cant);
}
public class DealerClasico : IDealer<int>
{
    public List<Mano<int>> Reparte(List<Ficha<int>> mazo, int jugadores, int cant)
    {
        Random r = new Random();
        List<Mano<int>> list = new List<Mano<int>>();
        for(int i = 0; i< jugadores;i++){
            list.Add(new Mano<int>());
        }
        for(int i = 0; i< jugadores;i++){
            for(int j = 0;j<cant;j++){
                int aux = r.Next(mazo.Count);
                list[i].Contenido.Add(mazo[aux]);
                mazo.Remove(mazo[aux]);
            }
        }
        return list;
    }
}
