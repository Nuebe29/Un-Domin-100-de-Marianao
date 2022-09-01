namespace Engine;

public class Partida<T>
{
    public Tablero<T> Tablero { get; }
    public List<Player<T>> Players { get; set; }
    private Referee<T> Referee { get; }

    public Partida(IEndcondition<T> endcondition, IWincondition<T> wincondition, IMatcher<T> matcher, IDealer<T> dealer,
     IGenerador<T> generador, List<Player<T>> players, T n, ITurner<T> turner, int cantidad)
    {
        Tablero = new Tablero<T>();
        Tablero.Hoja.Salida = true;
        Players = players;
        Referee = new Referee<T>(endcondition, wincondition, matcher, dealer, generador, players, n, Tablero, turner, cantidad);
    }
    public void Run() => Referee.Run();
    public bool Run(int a)=> Referee.Run(a);
}