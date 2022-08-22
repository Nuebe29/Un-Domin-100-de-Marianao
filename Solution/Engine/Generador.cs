namespace Engine;


public interface IGenerador<T>{
    public List<Ficha<T>> Generamazo(T value);
}
public class Generadorclasico:IGenerador<int>
{
    

    public List<Ficha<int>> Generamazo(int value)
    {
        List<Ficha<int>> list = new List<Ficha<int>>();
        for(int i = 0; i<value+1;i++){
            for(int j = i; j<value+1;j++){
                list.Add(new Ficha<int>(i,j, i+j));
            }
        }
        return list;
    }

    
}