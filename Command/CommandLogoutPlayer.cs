class CommandLogoutPlayer : ICommand
{
    public string NameCommand() { return "logout"; }
    public string DescriptionCommand() { return "  - вийти з акаунту"; }

    PlayerService adminPlayer;
    RegisteredAccountService adminRegisteredAccount;

    PasswordHasher hash = new PasswordHasher();

    public CommandLogoutPlayer(PlayerService adminPlayerObj, RegisteredAccountService adminRegisteredAccountObj)
    {
        adminPlayer = adminPlayerObj;
        adminRegisteredAccount = adminRegisteredAccountObj;
    }

    public void Command() 
    {
        if(adminPlayer.AccountCount() < 1) {
            Console.WriteLine("Немає створених акаунтів\n");
            return;
        }

        if(!adminRegisteredAccount.CheckRegisteredAccount()) {
            Console.WriteLine(adminRegisteredAccount.GetRegisteredAccount());
            Console.WriteLine("Спочатку ввійдіть в акаунту");
            return;   
        }

        adminRegisteredAccount.WriteRegisteredAccount(null);    
        Console.WriteLine("Вихід успішний");

    }
}
