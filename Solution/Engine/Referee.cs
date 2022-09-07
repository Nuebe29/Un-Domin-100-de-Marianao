namespace Engine;


public class Referee<T>{
    private IEndcondition<T> Endcondition;
    private IGenerador<T> Generador;
    private Dealer<T> Dealer;
    public List<Mano<T>> Manos { get; }
    private IMatcher<T> Matcher { get; }
    public Tablero<T> Tablero {get; }
    public List<Player<T>> Players { get; }
    private IWincondition<T> Wincondition;
    public int Pases { get; set; }
    private int Turno = -1;
    private IEnumerator<int> turnEnumerator;

    public Referee(IEndcondition<T> endcondition, IWincondition<T> wincondition, IMatcher<T> matcher,Dealer<T> dealer,
     IGenerador<T> generador,List<Player<T>> players, T n,Tablero<T> tablero, ITurner<T> turner, int cantidad)
    {
        Endcondition = endcondition;
        Dealer = dealer;
        Wincondition = wincondition;
        Generador  = generador;
        Matcher = matcher;
        Players = players;
        Manos = Dealer.Reparte(Generador.Generamazo(n), players.Count,cantidad  );
        Tablero = tablero;
        Pases = 0;
        turnEnumerator = turner.Turno(players.Count).GetEnumerator();
    }

    public void Run()
    {

        while (!Endcondition.Condicion(Manos,Pases,Tablero))
        {
            Turno++;
            var LeToca = turnEnumerator.Current;
            Matcher.Jugabilidad(Tablero,LeToca);
            var PosiblesJugadas = Matcher.SacarJugadas(Tablero, Manos, LeToca);
            var j = Players[LeToca].Juega(Tablero, PosiblesJugadas.ToList(), Manos[LeToca].Clone());
            EfectuarJugada(PosiblesJugadas[j], Tablero, Manos, LeToca, Turno);
            
            turnEnumerator.MoveNext();
        }
        Wincondition.Ordena(Manos, Players, Tablero);
    }
    public void EfectuarJugada(Movimiento<T> jugada, Tablero<T> tablero, List<Mano<T>> manos, int letoca, int turno)
    {
        if (!jugada.EsPase)
        {
            Pases = 0;
            manos[letoca].Remove(jugada.Ficha);
            foreach (Tablero<T> t in tablero)
            {
                if (t.Hoja == jugada.Nodo)
                {
                    if (jugada.Nodo.Salida)
                    {
                        t.Ramas.Add(new Tablero<T>(jugada.Ficha.Cara2,turno ,jugada.Ficha,letoca));
                        t.Ramas.Add(new Tablero<T>(jugada.Ficha.Cara1, turno,jugada.Ficha,letoca));
                    }
                    else t.Ramas.Add(new Tablero<T>(jugada.Entrada, turno   ,jugada.Ficha,letoca));          
                    Matcher.Jugabilidad(t,tablero,letoca, Players.Count);

                }
            }

        }

        else Pases++;
    }
    public bool RunTurn(){
        if(!Endcondition.Condicion(Manos,Pases,Tablero)){
            Turno++;
            turnEnumerator.MoveNext();
            var LeToca = turnEnumerator.Current;
            Matcher.Jugabilidad(Tablero,LeToca);
            var PosiblesJugadas = Matcher.SacarJugadas(Tablero, Manos, LeToca);
            var j = Players[LeToca].Juega(Tablero, PosiblesJugadas, Manos[LeToca]);
            EfectuarJugada(PosiblesJugadas[j], Tablero, Manos, LeToca, Turno);
            
            return false;
        }
        
        Wincondition.Ordena(Manos, Players, Tablero);
        return true;
    }
    

    
}
