namespace Engine;

public interface IReferee<T>{
        public void run(){

        }
    }
    public class RefereeClasico:IReferee<int>{
        private List<Player<int>> players;
        private IEndcondition<int> endcondition;
        private IGenerador<int> generador;
        private IDealer<int> dealer;
        private List<Mano<int>> manos;
        private IMatcher<int> matcher;
        private IWincondition<int> wincondition;

        public RefereeClasico(List<Player<int>> players, IEndcondition<int> endcondition, IGenerador<int> generador, IDealer<int> dealer, List<Mano<int>> manos, IMatcher<int> matcher, IWincondition<int> wincondition)
        {
            this.players = players;
            this.endcondition = endcondition;
            this.generador = generador;
            this.dealer = dealer;
            this.manos = manos;
            this.matcher = matcher;
            this.wincondition = wincondition;
        }

        private void run(){

        }
    }