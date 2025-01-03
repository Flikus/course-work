class CommandPlayGame : ICommand
{
    public string NameCommand() { return "playGame"; }
    public string DescriptionCommand() { return "  - зігарти гру"; }


    PlayerService adminPlayer;
    GameService adminGame;  
    RegisteredAccountService adminRegisteredAccount;

    public CommandPlayGame(PlayerService adminPlayerObj, GameService adminGameObj, RegisteredAccountService adminRegisteredAccountObj)
    {
        adminPlayer = adminPlayerObj;
        adminGame = adminGameObj;
        adminRegisteredAccount = adminRegisteredAccountObj;
    }
    
    public void Command()
    {
        if(!adminRegisteredAccount.CheckRegisteredAccount()) {
            Console.WriteLine("Спочатку ввійдіть в акаунт\n");  
            return;
        }

        string userName1 = adminRegisteredAccount.GetRegisteredAccount();
        string userName2;
        string strGameIndex;
        int gameIndex;


        if(adminPlayer.AccountCount() < 2) {
            Console.WriteLine("Для гри потрібно мінімум 2 створених акаунти\n");  
            return;          
        }

        if(adminGame.GameCount() < 1) {
            Console.WriteLine("Немає створених ігор\n");  
            return;
        }


        do{
            Console.Write("Введіть ім'я опонента 2: ");
            // Зчитуємо перший символ
            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: false); //intercept - вивести символ на екран
            if (keyInfo.Key == ConsoleKey.Escape)
                return;
            userName2 = keyInfo.KeyChar.ToString();
            userName2 += Console.ReadLine(); 
            
            if(userName1 == userName2)
                Console.WriteLine("гравець не може зіграти сам з собою");

        } while(!adminPlayer.CheckExistAccount(userName2) || userName1 == userName2);

        adminGame.OutputAllGame();

        do {
            do{
                Console.Write("Введіть індекс гри: ");

                // Зчитуємо перший символ
                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: false); //intercept - вивести символ на екран
                if (keyInfo.Key == ConsoleKey.Escape)
                    return;
                strGameIndex = keyInfo.KeyChar.ToString();
                strGameIndex += Console.ReadLine();   

            } while(!int.TryParse(strGameIndex, out gameIndex));
        } while(!adminGame.CheckExistGame(gameIndex));

        
        PlayGame play = new PlayGame(adminPlayer.GetAccount(userName1), adminPlayer.GetAccount(userName2), adminGame.GetGame(gameIndex));

    }
}