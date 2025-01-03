class PlayGame
{
    GameAccount User1;
    GameAccount User2;
    Game Games;
    public PlayGame(GameAccount player1, GameAccount player2, Game games)
    {
        User1 = player1;
        User2 = player2;
        Games = games;

        DbPlayerShipService Player1 = new DbPlayerShipService(new DbPlayerShipRepository(new DbPlayerShip()));
        DbPlayerShipService Player2 = new DbPlayerShipService(new DbPlayerShipRepository(new DbPlayerShip()));
        DbPlayerShipService tempPlayer = new DbPlayerShipService(new DbPlayerShipRepository(new DbPlayerShip()));


        for(int i = 0; i < 2; i++)
        {
            Console.Clear();
            Console.WriteLine("Гравець " + (i+1));
            Console.WriteLine("Виберіть спосіб розташування:");
            Console.WriteLine("1. Ручне розташування кораблів");
            Console.WriteLine("2. Автоматичне розташування кораблів");
            Console.WriteLine("3. вийти з гри");
            
            int mode;

            do {
                Console.Write("\nСпосіб розташування: ");
            } while (!int.TryParse(Console.ReadLine(), out mode) || (mode != 1 && mode != 2 && mode != 3));


            switch(mode) 
            {
            case 1 : 
                tempPlayer = new DbPlayerShipService(new DbPlayerShipRepository(new DbPlayerShip()));
                if(!ManualPlaceShips("      Гравець " + (i+1) + "      ", tempPlayer)) { return; } 
                Console.ReadLine();
                break;  
            case 2 : 
                char ans;
                do {
                    tempPlayer = new DbPlayerShipService(new DbPlayerShipRepository(new DbPlayerShip()));
                    ans = AutoPlaceShips("      Гравець " + (i+1) + "      ", tempPlayer);
                    Console.ReadLine();
                    if(ans == 'x')
                        return;
                } while(ans == 'y');  
                break;
            case 3 : return;
            default: Console.WriteLine("Помилка: невірний режим гри"); return;
            }            

            if(i == 0)
                Player1 = tempPlayer;
            else
                Player2 = tempPlayer;
        }

        Player1.ClearMap();
        Player2.ClearMap();
        Player1.ClearUnreachableCellsPlayer();  // Тепер вона зберігатиме попдання по супернику
        Player2.ClearUnreachableCellsPlayer();  

        Console.Clear();
        Console.WriteLine("Гра починається!");

        int ind = Batle(Player1, Player2);

        Console.Clear();
        Console.WriteLine("Гра завершена!");        
        if(ind != 0) {

            Console.WriteLine("------------------------------");
            Console.WriteLine("| виграв | програв | рейтинг |");
            if(ind == 1) {
                Console.Write("|{0,7} |", User1.UserName);		
                Console.Write("{0,8} |" , User2.UserName);                
            }
            else {
                Console.Write("|{0,7} |", User2.UserName);		
                Console.Write("{0,8} |" , User1.UserName);         
            }
            Console.Write("{0, 8} |", Games.Rating);
            Console.WriteLine();
            Console.WriteLine("------------------------------");            
        }
        else {
            Console.WriteLine("Нічия!");
            Console.WriteLine("Кожному по " + Games.Rating + " рейтингу");
        }

    }

    private bool ManualPlaceShips(string str, DbPlayerShipService Player)
    {
        bool ind;
        List<int> shipSize = new List<int> { 4, 3, 3, 2, 2, 2, 1, 1, 1, 1 };
        
        for(int i = 0; i < shipSize.Count(); i++) {
            Console.Clear();
            Console.WriteLine(str);
            Player.PrintPlayerMap();

            List<List<char>> ship = new List<List<char>>();

            Console.WriteLine("Розміщення корабля довжиною " + shipSize[i]); 

            do {
                ind = false;  
                char tempChar;          
                ship.Add(new List<char>());       // Додаємо масив координат корабля
                
                do{
                    Console.Write("Введіть координату (a-j): ");
                    tempChar = (char)Console.Read();
                    Console.ReadLine();                 // Очищаємо залишкові символи, включаючи '\n'

                } while(tempChar < 'a' || tempChar > 'j');
                ship[0].Add(tempChar);                 // Записуємо координату носу корабля тому [0] 

                do{
                    Console.Write("Введіть координату (0-9): ");
                    tempChar = (char)Console.Read();
                    Console.ReadLine();                         // Очищаємо залишкові символи, включаючи '\n'

                } while(tempChar < '0' || tempChar > '9');
                ship[0].Add(tempChar);

                if(shipSize[i] > 1)
                    do{
                        Console.Write("Введіть напрямок (h - горизонтально, v - вертикально): ");
                        tempChar = (char)Console.Read();
                        Console.ReadLine();                             // Очищаємо залишкові символи, включаючи '\n'

                    } while(tempChar != 'h' && tempChar != 'v');
                


                for(int j = 1; j < shipSize[i]; j++) { //Записуємо іншу частину корабля
                    ship.Add(new List<char>());
                    if(tempChar == 'h') {          // Отримаємо {b5, c5, d5}
                        ship[j].Add((char)(ship[0][0] + j));
                        ship[j].Add(ship[0][1]);
                        if(ship[0][0] > 'j')
                            ind = true;
                    }
                    else {                         // Отримаємо {b5, b6, b7}
                        ship[j].Add(ship[0][0]);
                        ship[j].Add((char)(ship[0][1] + j));
                        if(ship[0][1] > '9')   
                            ind = true;          
                    }        
                }    

                Console.WriteLine("Бажаєте переставити корабель? (так - y, ні - enter)"); 
                if((char)Console.Read() == 'y') {
                    ind = true;
                    ship.Clear();
                    Console.ReadLine();                  
                }
                else if(ind) {
                    Console.WriteLine("Корабель виходить за межі поля");        
                    ship.Clear();            
                }
                else if(Player.ChekUnreachableCells(ship)) {   
                    Console.WriteLine("Неможливо розмістити корабель"); 
                    ship.Clear();
                    ind = true;                   
                }
                

            } while(ind);
            
            
            //копіюємо
            List<List<char>> shipCopy = new List<List<char>>();
            for (int k = 0; k < ship.Count; k++)
            {
                List<char> copiedInnerList = new List<char>();
                for (int l = 0; l < ship[k].Count; l++)
                {
                    copiedInnerList.Add(ship[k][l]);
                }
                shipCopy.Add(copiedInnerList);
            }
            //
            Player.GetShipCoordPlayer().Add(shipCopy);
            Player.UnreachableCells(ship);            
            Player.AddPlayerMap(ship);
            
            ship.Clear();

            Console.WriteLine("Бажаєте продовжити? (так - enter, ні - x)"); 
            Console.ReadLine();
            if(Console.Read() == 'x') {
                return false;
            }
            Console.ReadLine();
        }

        return true;
    }

    private char AutoPlaceShips(string str, DbPlayerShipService Player)
    {     
        Console.Clear();
        Console.WriteLine(str);
        
        Random random = new Random();
        
        bool ind;

        List<int> shipSize = new List<int> { 4, 3, 3, 2, 2, 2, 1, 1, 1, 1 };
        
        for(int i = 0; i < shipSize.Count(); i++) {
            List<List<char>> ship = new List<List<char>>();

            do{
                ind = false;            
                ship.Add(new List<char>());       // Додаємо масив координат корабля

                ship[0].Add((char)random.Next(97, 106));
                ship[0].Add((char)random.Next(48, 57));

                for(int j = 1; j < shipSize[i]; j++) { //Записуємо іншу частину корабля
                    ship.Add(new List<char>());
                    if(ship[0][0] - 'a' + ship[0][1] - '0' > 10) {  // Отримаємо {b5, c5, d5}
                        ship[j].Add((char)(ship[0][0] + j));
                        ship[j].Add(ship[0][1]);
                        if(ship[j][0] > 'j')
                            ind = true;
                    }
                    else {                         // Отримаємо {b5, b6, b7}
                        ship[j].Add(ship[0][0]);
                        ship[j].Add((char)(ship[0][1] + j));
                        if(ship[j][1] > '9')   
                            ind = true;          
                    }        
                }    

                if(ind){      
                    ship.Clear();            
                }
                else
                    if(Player.ChekUnreachableCells(ship)) {
                        ship.Clear();
                        ind = true;                   
                    }
            } while(ind);


            //копіюємо
            List<List<char>> shipCopy = new List<List<char>>();
            for (int k = 0; k < ship.Count; k++)
            {
                List<char> copiedInnerList = new List<char>();
                for (int l = 0; l < ship[k].Count; l++)
                {
                    copiedInnerList.Add(ship[k][l]);
                }
                shipCopy.Add(copiedInnerList);
            }
            //
            Player.GetShipCoordPlayer().Add(shipCopy);
            Player.UnreachableCells(ship);            
            Player.AddPlayerMap(ship);
            
            ship.Clear();
        }

        Player.PrintPlayerMap();
        Console.WriteLine("Бажаєте змінити? (так - y, ні - enter, вийти - x)"); 
        return (char)Console.Read();
    }
    
    private void PrintBatleMap(DbPlayerShipService Player1, DbPlayerShipService Player2)
    {
        Console.WriteLine("      Гравець 1      \t\t\t\tГравець 2      ");
        for(int i = 0; i < Player1.GetPlayerMapCountY(); i++) {
            Player1.PrintStringPlayerMap(i);
            Console.Write("\t\t\t");
            Player2.PrintStringPlayerMap(i);
            Console.WriteLine();
        }
    }

    private void BorderOfSunkShip(DbPlayerShipService Player, int index)
    {
        List<int> Border = Player.BorderOfSunkShip(Player.GetShipCoordPlayer()[index]);

        for(int i = Border[2]; i <= Border[3]; i++) 
            for(int j = Border[0]; j <= Border[1]; j++) 
                Player.AddMissedShipPlayerMap(new List<char> { (char)('a' + j), (char)('0' + i)});
                
    }

    private int Batle(DbPlayerShipService Player1, DbPlayerShipService Player2)
    {
        bool hit;
        int step = 1;
        int scoreP1 = 0;
        int scoreP2 = 0;
        
        List<List<List<char>>> downeShips1 = Player2.GetShipCoordPlayer();
        List<List<List<char>>> downeShips2 = Player1.GetShipCoordPlayer();  

        // глибоке копіювання
        List<List<List<char>>> downeShips1Copy = new List<List<List<char>>>();
        List<List<List<char>>> downeShips2Copy = new List<List<List<char>>>();
        //////////
        for (int i = 0; i < downeShips1.Count; i++)
        {
            List<List<char>> outerListCopy = new List<List<char>>();
            for (int j = 0; j < downeShips1[i].Count; j++)
            {
                List<char> innerListCopy = new List<char>(downeShips1[i][j]);
                outerListCopy.Add(innerListCopy);
            }
            downeShips1Copy.Add(outerListCopy);
        }
        for (int i = 0; i < downeShips2.Count; i++)
        {
            List<List<char>> outerListCopy = new List<List<char>>();
            for (int j = 0; j < downeShips2[i].Count; j++)
            {
                List<char> innerListCopy = new List<char>(downeShips2[i][j]);
                outerListCopy.Add(innerListCopy);
            }
            downeShips2Copy.Add(outerListCopy);
        }
        //////////


        while(scoreP1 != 20 || scoreP2 != 20) {
            hit = false;
            List<char> coord = new List<char>();
            char tempChar;
            Console.Clear();
            Console.WriteLine("Ходить гравець " + step);
            PrintBatleMap(Player1, Player2);



            do{
                Console.Write("Введіть координату (a-j): ");
                tempChar = (char)Console.Read();
                Console.ReadLine();                 // Очищаємо залишкові символи, включаючи '\n'

            } while(tempChar < 'a' || tempChar > 'j');
            coord.Add(tempChar);                    // Записуємо координату носу корабля тому [0] 

            do{
                Console.Write("Введіть координату (0-9): ");
                tempChar = (char)Console.Read();
                Console.ReadLine();                 // Очищаємо залишкові символи, включаючи '\n'

            } while(tempChar < '0' || tempChar > '9');
            coord.Add(tempChar); 



            if(step == 1) {
                if(Player1.GetUnreachableCellsPlayer().FindIndex(list => list.SequenceEqual(coord)) != -1)
                    Console.WriteLine("Ти вже стріляв туди");

                else{
                    Player1.GetUnreachableCellsPlayer().Add(new List<char>(coord));


                    for(int i = 0; i < Player1.GetShipCoordPlayer().Count(); i++)
                        for(int j = 0; j < Player1.GetShipCoordPlayer()[i].Count(); j++)
                            if(Player2.GetShipCoordPlayer()[i][j][0] == coord[0] && Player2.GetShipCoordPlayer()[i][j][1] == coord[1]) {

                                int index = downeShips1Copy[i].FindIndex(list => list.SequenceEqual(coord));
                                downeShips1Copy[i].Remove(downeShips1Copy[i][index]);
                                if(downeShips1Copy[i].Count() == 0) {
                                    BorderOfSunkShip(Player2, i);
                                    Player2.AddPlayerMap(Player2.GetShipCoordPlayer()[i]);
                                }
                                else
                                    Player2.AddPaddedShipPlayerMap(coord);

                                scoreP1++;                                
                                step = 2;
                                hit = true;
                            }
                    if(!hit) {
                        Player2.AddMissedShipPlayerMap(coord);
                        step = 2;
                    }    
                }
                             
            }
            else{
                if(Player2.GetUnreachableCellsPlayer().FindIndex(list => list.SequenceEqual(coord)) != -1)
                    Console.WriteLine("Ти вже стріляв туди");
                    
                else{
                    for(int i = 0; i < Player2.GetShipCoordPlayer().Count(); i++)
                        for(int j = 0; j < Player2.GetShipCoordPlayer()[i].Count(); j++)
                            if(Player1.GetShipCoordPlayer()[i][j][0] == coord[0] && Player1.GetShipCoordPlayer()[i][j][1] == coord[1]) {
                                
                                int index = downeShips2Copy[i].FindIndex(list => list.SequenceEqual(coord));
                                downeShips2Copy[i].Remove(downeShips2Copy[i][index]);
                                if(downeShips2Copy[i].Count() == 0) {
                                    BorderOfSunkShip(Player1, i);
                                    Player1.AddPlayerMap(Player1.GetShipCoordPlayer()[i]);
                                }
                                else
                                    Player1.AddPaddedShipPlayerMap(coord);
                                scoreP2++;
                                step = 1;
                                hit = true;
                            }
                    if(!hit) {
                        Player1.AddMissedShipPlayerMap(coord);
                        step = 1;
                    }      
                }          
            }

            Console.WriteLine("Бажаєте продовжити (так - enter, ні - x)"); 
            if((char)Console.Read() == 'x') {
                break;
            }
            Console.ReadLine();
        }


        if(scoreP1 > scoreP2) {
            User1.WinGame(User2.UserName, Games);
            User2.LoseGame(User1.UserName, Games);
            return 1;
        }
        else if(scoreP1 < scoreP2) {
            User1.LoseGame(User2.UserName, Games);            
            User2.WinGame(User1.UserName, Games);
            return -1;
        }
        else {
            User1.WinGame(User2.UserName, Games);            
            User2.WinGame(User1.UserName, Games);
            return 0;
        }
    }
}