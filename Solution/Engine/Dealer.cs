namespace Engine;
public interface IDealer<T>{
<<<<<<< HEAD
    public List<Mano<T>> Reparte(List<IFicha<T>> mazo, int jugadores);
}
public class DealerClasico6 : IDealer<int>
{
    public List<Mano<int>> Reparte(List<IFicha<int>> mazo, int jugadores)
=======
    public List<Mano<T>> Reparte(List<IFicha<T>> mazo, int jugadores, int cant);
}
public class DealerClasico : IDealer<int>
{
    public List<Mano<int>> Reparte(List<IFicha<int>> mazo, int jugadores, int cant)
>>>>>>> 0fbaf73d60127f9bca9bb720a32eddcf6a5a070a
    {
        Random r = new Random();
        List<Mano<int>> list = new List<Mano<int>>();
        for(int i = 0; i< jugadores;i++){
            list.Add(new Mano<int>());
        }
        for(int i = 0; i< jugadores;i++){
<<<<<<< HEAD
            for(int j = 0;j<8;j++){
=======
            for(int j = 0;j<cant;j++){
>>>>>>> 0fbaf73d60127f9bca9bb720a32eddcf6a5a070a
                list[i].Contenido.Add(mazo[r.Next(mazo.Count)]);
                mazo.Remove(mazo[r.Next(mazo.Count)]);
            }
        }
        return list;
    }
}
