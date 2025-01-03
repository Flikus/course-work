class CommandCreateGame : ICommand
{
    public string NameCommand() { return "createGame"; }
    public string DescriptionCommand() { return "  - створити гру"; }


    GameService adminGame;
    public CommandCreateGame(GameService adminGameObj)
    {
        adminGame = adminGameObj;
    }

    public void Command() {
        string? typeGame;
        string strRatting;
        int rating;

        do{
            Console.Write("Введіть тип гри (Standart, Onerisk, Training): ");

            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: false); //intercept - вивести символ на екран
            if (keyInfo.Key == ConsoleKey.Escape)
                return;
            typeGame = keyInfo.KeyChar.ToString();

            typeGame += Console.ReadLine(); 

        } while(!(typeGame == "Standart" || typeGame == "Onerisk" || typeGame == "Training"));


        do{
            Console.Write("Введіть рейтинг гри: ");
            
            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: false); //intercept - вивести символ на екран
            if (keyInfo.Key == ConsoleKey.Escape)
                return;
            strRatting = keyInfo.KeyChar.ToString();
            strRatting += Console.ReadLine();

            int.TryParse(strRatting, out rating);

            if(rating < 0)
                Console.WriteLine("Помилка: Рейтинг не може бути від'ємним");
            
        } while(!int.TryParse(strRatting, out rating) || rating < 0);

        adminGame.CreateGame(typeGame, rating);
        Console.Write("Гру успішно створено");
    }
}