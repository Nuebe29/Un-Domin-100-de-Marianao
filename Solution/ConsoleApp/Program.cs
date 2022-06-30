using Engine;

Engine.TableroClásico tableroclasico= new TableroClásico(0,0);
Engine.Generadorclasico generadorclasico = new Engine.Generadorclasico();
Engine.EndconditionClasico endconditionClasico= new Engine.EndconditionClasico();
List<Player<int>> list = new List<Player<int>>();
list.Add(new Player<int>(Estrategiarandom));
list.Add(new Player<int>(Estrategiarandom));
list.Add(new Player<int>(Estrategiarandom));
list.Add(new Player<int>(Estrategiarandom));
Engine.DealerClasico dealerClasico= new Engine.DealerClasico();
Engine.GanadorCálsico ganadorCálsico = new Engine.GanadorCálsico();
Engine.MatcherClasico matcherClasico = new MatcherClasico();




Engine.Partida<int> a = new Engine.Partida<int>(tableroclasico, list, endconditionClasico, generadorclasico, 6, dealerClasico,7,matcherClasico,ganadorCálsico);
a.run();

