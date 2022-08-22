using Engine;

List<Player<int>> list =  new List<Player<int>>();
list.Add(new Player<int>(Estrategias<int>.Botagordas, "yo"));
list.Add(new Player<int>(Estrategias<int>.Estrategiarandom, "tu"));
list.Add(new Player<int>(Estrategias<int>.Botagordas, "el"));
list.Add(new Player<int>(Estrategias<int>.Botagordas, "ella"));

var a = new Partida<int>(new EndconditionClasico(),new GanadorCálsico(), new MatcherLongana(), new DealerClasico(), new Generadorclasico(), list, 6, new TurnerClasico(), 7);
a.Run();
System.Console.WriteLine(a.Players[0].name);


