namespace Engine;

public class Partida<T>{
    private IMatcher<T> matcher;
    private IWincondition<T> wincondition;
    private Referee referee;
    private List<Player<T>> players;
    private Endcondition endcondition;
    private IGenerador<T> generador;
    private IDealer<T> dealer;
    private List<Mano<T>> manos;
    private Tablero<T> tablero;
    



}