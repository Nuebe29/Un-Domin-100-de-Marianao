namespace Engine;


public interface IGenerador<T>{
    public List<IFicha<T>> Generamazo();
}
public class Generadorclasico6:IGenerador<int>
{
    

    public List<IFicha<int>> Generamazo()
    {
        List<IFicha<int>> list = new List<IFicha<int>>();
        for(int i = 0; i<7;i++){
            for(int j = 0; j<7;j++){
                list.Add(new FichaClásica(i,j));
            }
        }
        return list;
    }

    
}