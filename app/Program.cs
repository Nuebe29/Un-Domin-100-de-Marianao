// See https://aka.ms/new-console-template for more information
using Domino;
mano<IFicha> player1 = new mano<IFicha>();
mano<IFicha> player2 = new mano<IFicha>();
mano<IFicha> player3 = new mano<IFicha>();
mano<IFicha> player4 = new mano<IFicha>();
mano<IFicha> player5 = new mano<IFicha>();
int count = 0;

for(int i = 0; i<7;i++){
    for(int j = i; j< 7;j++){
        
        Ficha f = new Ficha(i,j);
        count++;
        if(count<8){player1.Add(f);continue;}
        else if(count<15){player2.Add(f);continue;}
        else if(count<22){player3.Add(f); continue;}
        else{player4.Add(f);}
        
    }
}
player1.Sort();
player2.Sort();
player3.Sort();
player4.Sort();

List<IFicha> tablero = new List<IFicha>();

mano<IFicha> [] juego = new mano<IFicha>[4];
juego[0] = player1;
juego[1] = player2;
juego[2] = player3;
juego[3] = player4;
Ley ley = new Ley();
var winner = player5;

while(true){
    List<IFicha> a = tablero;
    for(int i = 0; i<4;i++){
        tablero = juego[i].juega(tablero,ley);
        if(juego[i].list.Count==0){
            winner = juego[i];
            break;
        }
        // if(a==tablero){
        //     winner = player1;
        //     for(int j = 1; j< 4;j++){
        //         if(juego[j].puntos()<winner.puntos())winner = juego[j];
        //     }
        //     break;
        // }

    }
    if(winner!=player5)break;
    

    
}

System.Console.WriteLine(winner);





