class CommandUpdateUserName : ICommand
{
    public string NameCommand() { return "updateName"; }
    public string DescriptionCommand() { return "  - змінити своє ім'я "; }


    PlayerService adminPlayer;
    RegisteredAccountService adminRegisteredAccount;

    public CommandUpdateUserName(PlayerService adminPlayerObj, RegisteredAccountService adminRegisteredAccountObj)
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

        string userName;

        do{        
            Console.Write("Введіть нове ім'я: ");

            // Зчитуємо перший символ
            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: false); //intercept - вивести символ на екран
            if (keyInfo.Key == ConsoleKey.Escape)
                return;
            userName = keyInfo.KeyChar.ToString();
            userName += Console.ReadLine(); 
            
            if(adminPlayer.CheckExistAccount(userName))
                Console.WriteLine("Користувач з таким ім'ям вже існує");

        }while(userName.Count() < 1 || adminPlayer.CheckExistAccount(userName));

        adminPlayer.UpdateUserName(adminRegisteredAccount.GetRegisteredAccount(), userName); 
        adminRegisteredAccount.WriteRegisteredAccount(userName);
        Console.Write("Ім'я успішно змінене");
    }
}