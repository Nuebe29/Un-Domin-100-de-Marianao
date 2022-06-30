namespace Engine;


public interface IGenerador<T>{
<<<<<<< HEAD
    public List<IFicha<T>> Generamazo(T value);
}
public class Generadorclasico:IGenerador<int>
=======
    public List<T> Generamazo(int value);
}
public class Generadorclasico:IGenerador<IFicha<int>>
>>>>>>> 0fbaf73d60127f9bca9bb720a32eddcf6a5a070a
{
    

    public List<IFicha<int>> Generamazo(int value)
    {
        List<IFicha<int>> list = new List<IFicha<int>>();
        for(int i = 0; i<value+1;i++){
            for(int j = 0; j<value+1;j++){
                list.Add(new FichaClásica(i,j));
            }
        }
        return list;
    }

    
}