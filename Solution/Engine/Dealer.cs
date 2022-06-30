namespace Engine;
public interface IDealer<T>{
    public List<Mano<T>> Reparte(List<IFicha<T>> mazo, int jugadores);
}
public class DealerClasico6 : IDealer<int>
{
    public List<Mano<int>> Reparte(List<IFicha<int>> mazo, int jugadores)
    {
        Random r = new Random();
        List<Mano<int>> list = new List<Mano<int>>();
        for(int i = 0; i< jugadores;i++){
            list.Add(new Mano<int>());
        }
        for(int i = 0; i< jugadores;i++){
            for(int j = 0;j<8;j++){
                list[i].Contenido.Add(mazo[r.Next(mazo.Count)]);
                mazo.Remove(mazo[r.Next(mazo.Count)]);
            }
        }
        return list;
    }
}
