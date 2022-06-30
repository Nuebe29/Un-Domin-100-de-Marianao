namespace Engine;

public class Partida<T>{
    
    
    
    private ITablero<T> tablero;
        private List<Player<int>> players;
        private IEndcondition<int> endcondition;
        private IGenerador<int> generador;
        private IDealer<int> dealer;
        private List<Mano<int>> manos;
        private IMatcher<int> matcher;
        private IWincondition<int> wincondition;
        public int winner;


    public Partida(ITablero<T> tablero, List<Player<int>> players, IEndcondition<int> endcondition, IGenerador<int> generador, IDealer<int> dealer, List<Mano<int>> manos, IMatcher<int> matcher, IWincondition<int> wincondition)
    {
        this.tablero = tablero;
        this.players = players;
        this.endcondition = endcondition;
        this.generador = generador;
        this.dealer = dealer;
        this.manos = dealer.Reparte(generador.Generamazo(),players.Count);
        this.matcher = matcher;
        this.wincondition = wincondition;
    }
    public void run(){
        

    }
}
    



