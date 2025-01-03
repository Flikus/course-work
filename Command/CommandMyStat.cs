class CommandMyStat : ICommand
{
    public string NameCommand() { return "myStat"; }
    public string DescriptionCommand() { return "  - вивести мої ігри"; }


    PlayerService adminPlayer;
    RegisteredAccountService adminRegisteredAccount;

    public CommandMyStat(PlayerService adminPlayerObj, RegisteredAccountService adminRegisteredAccountObj)
    {
        adminPlayer = adminPlayerObj;
        adminRegisteredAccount = adminRegisteredAccountObj;
    }

    public void Command()
    {
        if(!adminRegisteredAccount.CheckRegisteredAccount()) {
            Console.WriteLine("Спочатку ввійдіть в акаунт\n");  
            return;
        }

        adminPlayer.OutputAccountById(adminRegisteredAccount.GetRegisteredAccount()); 
    }
}