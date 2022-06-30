<<<<<<< HEAD
﻿using System.Collections;

namespace Engine;







=======
﻿namespace Engine;

public static class Leyes
{
    public static bool EsJugable(FichaClásica ficha, TableroClásico tablero)
    {
        return EsJugable(ficha, tablero.Entrada1) || EsJugable(ficha, tablero.Entrada2);
    }
    
    public static bool EsJugable(FichaClásica ficha, int entrada)
    {
        return ficha.cara1 == entrada || ficha.cara2 == entrada;
    }
>>>>>>> 0fbaf73d60127f9bca9bb720a32eddcf6a5a070a





    public FichaClásica Salida(List<FichaClásica> mano)
    {
        Random random = new Random();
        int n = random.Next(mano.Count);
        return mano[n];
    }

<<<<<<< HEAD





=======
public static class JuegoClásico
{
    public static void Colocar(FichaClásica ficha, TableroClásico tablero)
    {
        if (tablero.Contenido.Count == 0)
        {
            tablero.Contenido.Add(ficha);
            tablero.Entrada1 = ficha.cara1;
            tablero.Entrada2 = ficha.cara2;
        }
        
        else if (Leyes.EsJugable(ficha, tablero.Entrada1))
        {
            tablero.Contenido.Add(ficha);
            tablero.Entrada1 = ficha.cara1 == tablero.Entrada1 ? ficha.cara2 : ficha.cara1;
        }
        
        else if (Leyes.EsJugable(ficha, tablero.Entrada2))
        {
            tablero.Contenido.Add(ficha);
            tablero.Entrada2 = ficha.cara1 == tablero.Entrada2 ? ficha.cara2 : ficha.cara1;
        }

        else throw new Exception("Esa Jugada no es posible");
    }

    
}



>>>>>>> 0fbaf73d60127f9bca9bb720a32eddcf6a5a070a
