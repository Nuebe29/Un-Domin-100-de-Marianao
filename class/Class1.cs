namespace Domino
{
    public class DominoBoard<T>{
        List<IFicha<T>> tablero;
        T left;
        T right;
        public DominoBoard(){

        }
    }
    public interface IGame<Tmano,T> where Tmano : Imano<IFicha<T>,T>
    {
        public Tmano[] players { get; }
    }
    public interface IFicha<T>
    {
        public (T, T) value { get; }
        public int peso { get; }
    }
    public class Ficha : IFicha<int>
    {
        int c;
        int d;
        public Ficha(int a, int b)
        {
            c = a;
            d = b;
        }

        public (int, int) value => (c, d);

        public int peso => c + d;
    }

    public interface IFilter<TFicha>
    {
        bool Apply(TFicha ficha, List<TFicha> tablero);
    }
    public class Ley : IFilter<Ficha>
    {
        public Ley()
        {
        }

        public bool Apply(Ficha ficha, List<Ficha> tablero)
        {
            if (ficha.value.Item1 == tablero[tablero.Count - 1].value.Item2) { return true; }
            else if (ficha.value.Item2 == tablero[0].value.Item1) { return true; }
            ficha = vira(ficha);
            if (ficha.value.Item1 == tablero[tablero.Count - 1].value.Item2) { return true; }
            else if (ficha.value.Item2 == tablero[0].value.Item1) { return true; }
            return false;

        }
        public Ficha vira(Ficha ficha)
        {
            Ficha devolver = new Ficha(ficha.value.Item2, ficha.value.Item1);
            return devolver;

        }
    }

    public interface Imano<TFicha,T> where TFicha : IFicha<T>
    {
        void Add(TFicha ficha);
        void Remove(TFicha ficha);

        void Sort();

        int Total { get; }
    }
    public class mano<TFicha,T> : Imano<TFicha,T> where TFicha : IFicha<T>
    {
        public List<TFicha> list;


        public mano()
        {
            list = new List<TFicha>();

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
                    if (list[j].peso < list[j + 1].peso) Swap(j, j + 1);
                }
            }

        }
        private void Swap(int a, int b)
        {
            TFicha temp = list[a];
            list[a] = list[b];
            list[b] = temp;
        }
        public int total()
        {
            int devolver = 0;
            for (int i = 0; i < list.Count; i++)
            {
                devolver += list[i].peso;
            }
            return devolver;
        }
        public List<IFicha<T>> juega(List<IFicha<T>> tablero, IFilter<IFicha<T>> ley)
        {
            if (tablero.Count == 0)
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
                        IFicha<T> ficha = list[i];
                        if (ficha.value.Item1 == tablero[tablero.Count - 1].value.Item2 || ficha.value.Item2 == tablero[0].value.Item1)
                        {
                            if (ficha.value.Item1 == tablero[tablero.Count - 1].value.Item2) tablero.Add(ficha);
                            else if (ficha.value.Item2 == tablero[0].value.Item1) tablero.Insert(0, ficha);
                        }
                        else
                        {
                            ficha = new Ficha(ficha.value.Item2, ficha.value.Item1);
                            if (ficha.value.Item1 == tablero[tablero.Count - 1].value.Item2) tablero.Add(ficha);
                            else if (ficha.value.Item2 == tablero[0].value.Item1) tablero.Insert(0, ficha);
                        }
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
                a += list[i].peso;
            }
            return a;
        }
    }
}

