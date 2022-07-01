namespace Engine;

public interface IMatcher<T>{
    public bool matchea(IFicha<T> ficha, Nodo<int> nodo);
}
public class MatcherClasico : IMatcher<int>
{
    
    
    public bool matchea(IFicha<int> ficha, Nodo<int> nodo)
    {   
        if(nodo.Entrada==-1|| ficha.Cara1== nodo.Entrada|| ficha.Cara2== nodo.Entrada)return true;
        return false;
    }
}