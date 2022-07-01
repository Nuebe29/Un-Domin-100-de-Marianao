using Engine;


List<Player<int>> list = new List<Player<int>>();
list.Add(new Player<int>(Estrategias<int>.Estrategiarandom, "yo"));
list.Add(new Player<int>(Estrategias<int>.Estrategiarandom, "tu"));
list.Add(new Player<int>(Estrategias<int>.Estrategiarandom,"el"));
list.Add(new Player<int>(Estrategias<int>.Estrategiarandom,"ella"));





Engine.PartidaClásica a = new Engine.PartidaClásica( list,  6);
var b = a.run();
System.Console.WriteLine(b.name);

