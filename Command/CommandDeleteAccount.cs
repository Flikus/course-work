class CommandDeleteAccount : ICommand
{
    public string NameCommand() { return "deleteAccount"; }
    public string DescriptionCommand() { return " - видалити гравця"; } 

    PlayerService adminPlayer;
    RegisteredAccountService adminRegisteredAccount;

    public CommandDeleteAccount(PlayerService adminPlayerObj, RegisteredAccountService adminRegisteredAccountObj)
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

        adminPlayer.DeletePlayer(adminRegisteredAccount.GetRegisteredAccount());
        adminRegisteredAccount.WriteRegisteredAccount(null);

        Console.WriteLine("Акаунт успішно видалено");
    }
}