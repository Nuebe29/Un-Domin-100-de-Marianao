namespace Engine;

public interface IEndcondition<T>{
    public bool Condicion(List<Mano<T>> list, int pases);
}
public class EndconditionClasico : IEndcondition<int>
{
    

    public bool Condicion(List<Mano<int>> list, int pases)
    {
        if(pases== list.Count)return true;
        foreach(var mano in list){
            if(mano.Contenido.Count==0)return true;
        }
        return false;
    }
}
