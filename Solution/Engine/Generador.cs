namespace Engine;


public interface IGenerador<T>{
    public List<IFicha<T>> Generamazo(T value);
}
public class Generadorclasico:IGenerador<int>
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