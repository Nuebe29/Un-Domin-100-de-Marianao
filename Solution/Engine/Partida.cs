namespace Engine;

public class PartidaClásica
{

    public PartidaClásica(List<Player<int>> players, int n)
    {
        Tablero = new TableroClásico(-1, -1);
        Players = players;
        Endcondition = new EndconditionClasico();
        Generador = new Generadorclasico();
        Dealer = new DealerClasico();
        Manos = Dealer.Reparte(Generador.Generamazo(n), players.Count, n+1 );
        Matcher = new MatcherClasico();
        Referee = new RefereeClásico(Matcher);
        Wincondition = new GanadorCálsico();
    }
    
    public  TableroClásico Tablero { get; }
    public List<Player<int>> Players { get; }
    private EndconditionClasico Endcondition;
    private Generadorclasico Generador;
    private DealerClasico Dealer;
    public List<Mano<int>> Manos { get; }
    public MatcherClasico Matcher { get; }
    private RefereeClásico Referee { get; }
    private GanadorCálsico Wincondition;
    public Player<int> run()
    {
        int t = 0;
        

        while (!Endcondition.Condicion(Manos,Referee.Pases))
        {
            
            var i = t % Players.Count;

            var PosiblesJugadas = Referee.SacarJugadas(Tablero, Manos, i);
            var j = Players[i].Juega(Tablero, PosiblesJugadas, Manos[i]);
            Referee.EfectuarJugada(PosiblesJugadas[j], Tablero, Manos, i);
            
            t += 1;
        }
        return Players[Wincondition.DecidirGanador(Manos)];
    }
}
public class PartidaLongana{
    public PartidaLongana(List<Player<int>> players, int n)
    {
        Tablero = new TableroClásico(-1, -1);
        Players = players;
        Endcondition = new EndconditionClasico();
        Generador = new Generadorclasico();
        Dealer = new DealerClasico();
        Manos = Dealer.Reparte(Generador.Generamazo(n), players.Count, n+1 );
        Matcher = new MatcherLongana();
        Referee = new RefereeLongana(Matcher);
        Wincondition = new GanadorCálsico();
    }
    
    public  TableroClásico Tablero { get; }
    public List<Player<int>> Players { get; }
    private EndconditionClasico Endcondition;
    private Generadorclasico Generador;
    private DealerClasico Dealer;
    public List<Mano<int>> Manos { get; }
    public MatcherLongana Matcher { get; }
    private RefereeLongana Referee { get; }
    private GanadorCálsico Wincondition;
    public Player<int> run()
    {
        int t = 0;
        

        while (!Endcondition.Condicion(Manos,Referee.Pases))
        {
            
            var i = t % Players.Count;

            var PosiblesJugadas = Referee.SacarJugadas(Tablero, Manos, i);
            var j = Players[i].Juega(Tablero, PosiblesJugadas, Manos[i]);
            Referee.EfectuarJugada(PosiblesJugadas[j], Tablero, Manos, i);
            
            t += 1;
        }
        return Players[Wincondition.DecidirGanador(Manos)];
    }
}
public class PartidaClásicax5{
    public PartidaClásicax5(List<Player<int>> players, int n)
    {
        Tablero = new TableroClásico(-1, -1);
        Players = players;
        Endcondition = new EndconditionClasico();
        Generador = new Generadorclasico();
        Dealer = new DealerClasico();
        Manos = Dealer.Reparte(Generador.Generamazo(n), players.Count, n+1 );
        Matcher = new MatcherClasico();
        Referee = new RefereeClásicox5(Matcher);
        Wincondition = new GanadorMultiplosx5();
    }
    
    public  TableroClásico Tablero { get; }
    public List<Player<int>> Players { get; }
    private EndconditionClasico Endcondition;
    private Generadorclasico Generador;
    private DealerClasico Dealer;
    public List<Mano<int>> Manos { get; }
    public MatcherClasico Matcher { get; }
    private RefereeClásicox5 Referee { get; }
    private GanadorMultiplosx5 Wincondition;
    public Player<int> run()
    {
        int t = 0;
        

        while (!Endcondition.Condicion(Manos,Referee.Pases))
        {
            
            var i = t % Players.Count;

            var PosiblesJugadas = Referee.SacarJugadas(Tablero, Manos, i);
            var j = Players[i].Juega(Tablero, PosiblesJugadas, Manos[i]);
            Referee.EfectuarJugada(PosiblesJugadas[j], Tablero, Manos, i);
            
            t += 1;
        }
        Wincondition.Puntos=Referee.Puntos;
        return Players[Wincondition.DecidirGanador(Manos)];
    }
}
public class PartidaLonganax5{
    public PartidaLonganax5(List<Player<int>> players, int n)
    {
        Tablero = new TableroClásico(-1, -1);
        Players = players;
        Endcondition = new EndconditionClasico();
        Generador = new Generadorclasico();
        Dealer = new DealerClasico();
        Manos = Dealer.Reparte(Generador.Generamazo(n), players.Count, n+1 );
        Matcher = new MatcherLongana();
        Referee = new RefereeLonganax5(Matcher);
        Wincondition = new GanadorMultiplosx5();
    }
    
    public  TableroClásico Tablero { get; }
    public List<Player<int>> Players { get; }
    private EndconditionClasico Endcondition;
    private Generadorclasico Generador;
    private DealerClasico Dealer;
    public List<Mano<int>> Manos { get; }
    public MatcherLongana Matcher { get; }
    private RefereeLonganax5 Referee { get; }
    private GanadorMultiplosx5 Wincondition;
    public Player<int> run()
    {
        int t = 0;
        

        while (!Endcondition.Condicion(Manos,Referee.Pases))
        {
            
            var i = t % Players.Count;

            var PosiblesJugadas = Referee.SacarJugadas(Tablero, Manos, i);
            var j = Players[i].Juega(Tablero, PosiblesJugadas, Manos[i]);
            Referee.EfectuarJugada(PosiblesJugadas[j], Tablero, Manos, i);
            
            t += 1;
        }
        Wincondition.Puntos=Referee.Puntos;
        return Players[Wincondition.DecidirGanador(Manos)];
    }
}
    



