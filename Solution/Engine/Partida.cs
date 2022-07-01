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
    public int winner { get; set; }
    public void run()
    {
        int t = 0;

        while (true)
        {
            var i = t % Players.Count;

            var PosiblesJugadas = Referee.SacarJugadas(Tablero, Manos[i]);
            var j = Players[i].Juega(Tablero, PosiblesJugadas, Manos[i]);
            Referee.EfectuarJugada(PosiblesJugadas[j], Tablero, Manos[i]);
            
            t += 1;
        }
    }
}
    



