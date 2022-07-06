namespace Engine;

public interface IMatcher<T>
{
    public bool matchea(IFicha<T> ficha, Nodo<int> nodo);
    public bool matchea(T value, T value2 );
}
public class MatcherClasico : IMatcher<int>
{


    public bool matchea(IFicha<int> ficha, Nodo<int> nodo)
    {
        if (nodo.Entrada == -1 || ficha.Cara1 == nodo.Entrada || ficha.Cara2 == nodo.Entrada) return true;
        return false;
    }
    public bool matchea(int value, int value2){
        if(value==value2)return true;
        return false;
    }

    
}
public class MatcherLongana : IMatcher<int>
{
    public bool matchea(IFicha<int> ficha, Nodo<int> nodo)
    {
        if (nodo.Entrada == -1 && ficha.Cara1==ficha.Cara2) return true;
        else if(ficha.Cara1 == nodo.Entrada || ficha.Cara2 == nodo.Entrada) return true;
        return false;
    }
    public bool matchea(int value, int value2){
        if(value==value2)return true;
        return false;
    }

    
}