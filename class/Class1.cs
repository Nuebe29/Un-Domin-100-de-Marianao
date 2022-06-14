namespace Domino
{
    public interface IGame<Tmano> where Tmano : Imano<IFicha>
    {
        public Tmano[] players { get; }
    }
    public interface IFicha
    {
        public (int, int) value { get; }
        public int sum { get; }
    }
    public class Ficha : IFicha
    {
        int c;
        int d;
        public Ficha(int a, int b)
        {
            c = a;
            d = b;
        }

        public (int, int) value => (c, d);

        public int sum => c + d;
    }

    public interface IFilter<T>
    {
        bool Apply(IFicha ficha, List<IFicha> tablero);
    }
    public class Ley : IFilter<IFicha>
    {
        public Ley()
        {
        }

        public bool Apply(IFicha ficha, List<IFicha> tablero)
        {
            if (ficha.value.Item1 == tablero[tablero.Count - 1].value.Item2) { return true; }
            else if (ficha.value.Item2 == tablero[0].value.Item1) { return true; }
            ficha = vira(ficha);
            if (ficha.value.Item1 == tablero[tablero.Count - 1].value.Item2) { return true; }
            else if (ficha.value.Item2 == tablero[0].value.Item1) { return true; }
            return false;

        }
        public IFicha vira(IFicha ficha)
        {
            Ficha devolver = new Ficha(ficha.value.Item2, ficha.value.Item1);
            return devolver;

        }
    }

    public interface Imano<TFicha> where TFicha : IFicha
    {
        void Add(TFicha ficha);
        void Remove(TFicha ficha);

        void Sort();

        int Total { get; }
    }
    public class mano<TFicha> : Imano<TFicha> where TFicha : IFicha
    {
        public List<IFicha> list;


        public mano()
        {
            list = new List<IFicha>();

        }

        public int Total => total();

        public void Add(TFicha ficha)
        {
            list.Add(ficha);
        }

        public void Remove(TFicha ficha)
        {
            list.Remove(ficha);
        }

        public void Sort()
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count - 1; j++)
                {
                    if (list[j].sum < list[j + 1].sum) Swap(j, j + 1);
                }
            }

        }
        private void Swap(int a, int b)
        {
            IFicha temp = list[a];
            list[a] = list[b];
            list[b] = temp;
        }
        public int total()
        {
            int devolver = 0;
            for (int i = 0; i < list.Count; i++)
            {
                devolver += list[i].sum;
            }
            return devolver;
        }
        public List<IFicha> juega(List<IFicha> tablero, IFilter<IFicha> ley)
        {
            if (tablero.Count==0)
            {
                tablero.Add(list[0]);
                list.Remove(list[0]);
            }
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (ley.Apply(list[i], tablero))
                    {
                        IFicha ficha = list[i];
                        if (ficha.value.Item1 == tablero[tablero.Count - 1].value.Item2) tablero.Add(ficha);
                        else if (ficha.value.Item2 == tablero[0].value.Item1) tablero.Insert(0, ficha);
                        ficha = new Ficha(ficha.value.Item2, ficha.value.Item1);
                        if (ficha.value.Item1 == tablero[tablero.Count - 1].value.Item2) tablero.Add(ficha);
                        else if (ficha.value.Item2 == tablero[0].value.Item1) tablero.Insert(0, ficha);
                        list.Remove(list[i]);
                        break;
                    }
                }
            }
            return tablero;
        }
        public int puntos()
        {
            int a = 0;
            for (int i = 0; i < list.Count; i++)
            {
                a += list[i].sum;
            }
            return a;
        }
    }
}

