class CommandImageAllGame : ICommand
{
    public string NameCommand() { return "imageAllGame"; }
    public string DescriptionCommand() { return "  - вивести всі ігри"; }


    GameService adminGame;
    public CommandImageAllGame(GameService adminGameObj)
    {
        adminGame = adminGameObj;
    }

    public void Command()
    {
        if(adminGame.GameCount() < 1) 
            Console.WriteLine("Немає створених ігор\n");
        else
            adminGame.OutputAllGame();
    }
}