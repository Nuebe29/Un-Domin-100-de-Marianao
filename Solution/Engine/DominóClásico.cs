using System.Collections;

namespace Engine;












    public FichaClásica Salida(List<FichaClásica> mano)
    {
        Random random = new Random();
        int n = random.Next(mano.Count);
        return mano[n];
    }






