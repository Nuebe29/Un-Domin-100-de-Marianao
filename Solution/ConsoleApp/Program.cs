using Engine;

List<JugadorRandom> jugadores = new List<JugadorRandom>();
jugadores.Add(new JugadorRandom("Pedro"));
jugadores.Add(new JugadorRandom("Gazpacho"));
jugadores.Add(new JugadorRandom("GatitaGolosa64"));
jugadores.Add(new JugadorRandom("Euclides"));

List<Mano> manos = new List<Mano>();
manos.Add(new Mano());
manos.Add(new Mano());
manos.Add(new Mano());
manos.Add(new Mano());

TableroClásico tablero = new TableroClásico(-1,-1);

List<FichaClásica> mazo = Generador.Genera(9);
Repartidor.Reparte(mazo, 10, manos);

Console.WriteLine($"Sale {jugadores[0].Name}");
FichaClásica ficha = jugadores[0].Salida(manos[0].Contenido);
JuegoClásico.Colocar(ficha, tablero);
manos[0].Remuve(ficha);
Console.WriteLine($"{jugadores[0].Name} jugó el {ficha}");

int i = 1;
int pases = 0;

while (true)
{
      if (pases == jugadores.Count)
      {
            Console.WriteLine($"El ganador es {JuegoClásico.DecidirGanador(jugadores, manos).Name}");
            break;
      }

      Console.WriteLine($"Turno de {jugadores[i % 4].Name}");
      
      
      if (Leyes.EsJugable(manos[i % 4], tablero))
      {
            ficha = jugadores[i % 4].Jugada(manos[i % 4].Contenido, tablero);
            JuegoClásico.Colocar(ficha, tablero);
            manos[i % 4].Remuve(ficha);
            Console.WriteLine($"{jugadores[i % 4].Name} jugó el {ficha}");

            if (manos[i % 4].Contenido.Count == 0)
            {
                  Console.WriteLine($"El ganador es {jugadores[i % 4].Name}"); 
                  break;
            }

            pases = 0;
      }

      else
      {
            Console.WriteLine($"{jugadores[i % 4].Name} se pasó");
            pases += 1;
      }

      i++;
}

