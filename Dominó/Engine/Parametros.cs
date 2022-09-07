namespace Engine;

public class Parametros
{
    public Parametros()
    {
        Matcher = new MatcherClasico();
        WinCondición = new GanadorCálsico();
        Endcondition = new EndconditionClasico();
        Turner = new TurnerClasico();
        Players = new List<Player<int>>();
    }
    
    public IMatcher<int> Matcher { get; set; }
    public IWincondition<int> WinCondición { get; set; }
    public IEndcondition<int> Endcondition { get; set; }
    public ITurner<int> Turner { get; set; }
    public List<Player<int>> Players { get; set; }
    
}