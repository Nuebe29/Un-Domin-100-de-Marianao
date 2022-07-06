using Engine;


List<Player<int>> list = new List<Player<int>>();
list.Add(new Player<int>(Estrategias<int>.Botagordas, "yo"));
list.Add(new Player<int>(Estrategias<int>.Botagordas, "tu"));
list.Add(new Player<int>(Estrategias<int>.Estrategiarandom,"el"));
list.Add(new Player<int>(Estrategias<int>.Estrategiarandom,"ella"));






Engine.PartidaLonganax5 a = new Engine.PartidaLonganax5( list,  6);
var b = a.run();
System.Console.WriteLine(b.name);

