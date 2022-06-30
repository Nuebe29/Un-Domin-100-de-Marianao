namespace Engine;

public class Partida<T>{
<<<<<<< HEAD
    
    
    
        public readonly ITablero<T> tablero;
        private List<Player<T>> players;
        private IEndcondition<T> endcondition;
        private IGenerador<T> generador;
        private IDealer<T> dealer;
        public readonly List<Mano<T>> manos;
        private IMatcher<T> matcher;
        private IWincondition<T> wincondition;
        public int? winner;


    public Partida(ITablero<T> tablero, List<Player<T>> players, IEndcondition<T> endcondition, IGenerador<T> generador,T generate, IDealer<T> dealer,int cant, List<Mano<T>> manos, IMatcher<T> matcher, IWincondition<T> wincondition)
    {
        this.tablero = tablero;
        this.players = players;
        this.endcondition = endcondition;
        this.generador = generador;
        this.dealer = dealer;
        this.manos = dealer.Reparte(generador.Generamazo(generate),players.Count, cant);
        this.matcher = matcher;
        this.wincondition = wincondition;
    }
    public void run(){
        
        int pases = 0;
        Random r = new Random();
        int i = r.Next(players.Count-1);
        
            while(true){
                if(endcondition.Condicion(manos,pases))break;
                List<IFicha<T>> posibles = new List<IFicha<T>>();
                foreach(var ficha in manos[i].Contenido){
                    if(matcher.matchea(ficha, tablero))posibles.Add(ficha);

                }
                if(posibles.Count==0){pases++;continue;}
                var aux = posibles[players[i].Juega(tablero, posibles, manos[i])];
                tablero.Add(aux); 
                manos[i].Remove(aux);
                pases=0; 
            
        }
        winner = wincondition.DecidirGanador(manos);
        

    }
}
=======
    private IMatcher<T> matcher;
    private IWincondition<T> wincondition;
    private Referee referee;
    private List<Player<T>> players;
    private Endcondition endcondition;
    private IGenerador<T> generador;
    private IDealer<T> dealer;
    private List<Mano<T>> manos;
    private Tablero<T> tablero;
>>>>>>> 0fbaf73d60127f9bca9bb720a32eddcf6a5a070a
    



<<<<<<< HEAD
=======
}
>>>>>>> 0fbaf73d60127f9bca9bb720a32eddcf6a5a070a
