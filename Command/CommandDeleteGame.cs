class CommandDeleteGame : ICommand
{
    public string NameCommand() { return "deleteGame"; }
    public string DescriptionCommand() { return " - видалити гру"; } 

    GameService adminGame;

    public CommandDeleteGame(GameService adminGameObj)
    {
        adminGame = adminGameObj;
    }

    public void Command()
    {
        if(adminGame.GameCount() < 1) {
            Console.WriteLine("Немає створених ігор\n");  
            return;
        }

        int index;
        string strIndex;

        adminGame.OutputAllGame();

        do{
            Console.Write("Введіть індекс гри: ");
            
            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: false); //intercept - вивести символ на екран
            if (keyInfo.Key == ConsoleKey.Escape)
                return;
            strIndex = keyInfo.KeyChar.ToString();
            strIndex += Console.ReadLine();

            

            if(!int.TryParse(strIndex, out index))
                Console.WriteLine("Вводіть тільки числа");
            
        } while(!int.TryParse(strIndex, out index));

        if(index >= 0 && index < adminGame.GameCount())
            Console.WriteLine("Гру успішно видалено");

        adminGame.DeleteGame(index);

    }
}
