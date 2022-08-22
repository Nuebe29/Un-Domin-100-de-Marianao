namespace Engine;

public delegate int Estrategia<T>(Tablero<T> estado, List<Movimiento<T>> posiblesjugadas, Mano<T> hand);
public static class Estrategias<T>
{
    public static int Estrategiarandom(Tablero<T> estado, List<Movimiento<T>> posiblesjugadas, Mano<T> hand){
        Random r = new Random();
        return r.Next(posiblesjugadas.Count);
    }
    public static int Botagordas(Tablero<T> estado, List<Movimiento<T>> posiblesjugadas, Mano<T> hand){
        
        int devolver = 0;
        int peso = 0;
        for(int i = 0; i< posiblesjugadas.Count;i++){
            if(posiblesjugadas[i].EsPase)continue;
            if(posiblesjugadas[i].Ficha.Peso>peso){devolver=i;peso = posiblesjugadas[i].Ficha.Peso;}
        }
        return devolver;
    }
    
}