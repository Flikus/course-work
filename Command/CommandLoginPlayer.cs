class CommandLoginPlayer : ICommand
{
    public string NameCommand() { return "login"; }
    public string DescriptionCommand() { return "  - залогінитись"; }

    PlayerService adminPlayer;
    RegisteredAccountService adminRegisteredAccount;
    PasswordHasher hash = new PasswordHasher();


    public CommandLoginPlayer(PlayerService adminPlayerObj, RegisteredAccountService adminRegisteredAccountObj)
    {
        adminPlayer = adminPlayerObj;
        adminRegisteredAccount = adminRegisteredAccountObj;
    }

    public void Command() 
    {
        string userName;
        string password;


        if(adminPlayer.AccountCount() < 1) {
            Console.WriteLine("Немає зареєстрованих акаунтів\n");
            return;
        }

        if(adminRegisteredAccount.CheckRegisteredAccount()) {
            Console.WriteLine("Спочатку вийдіть з поточного акаунту\n");
            return;   
        }

        do{        
            Console.Write("Введіть ім'я: ");

            // Зчитуємо перший символ
            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: false); //intercept - вивести символ на екран
            if (keyInfo.Key == ConsoleKey.Escape)
                return;
            userName = keyInfo.KeyChar.ToString();
            userName += Console.ReadLine(); 
            
        }while(userName.Count() < 1 || !adminPlayer.CheckExistAccount(userName));
        
        do { 
            Console.Write("Введіть пароль: ");

            // Зчитуємо перший символ
            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: false); //intercept - вивести символ на екран
            if (keyInfo.Key == ConsoleKey.Escape)
                return;
            password = keyInfo.KeyChar.ToString();
            password += Console.ReadLine();
            
        } while(password == null);

        if(hash.VerifyPassword(password, adminPlayer.CheckPlayerPassword(userName))) {
            adminRegisteredAccount.WriteRegisteredAccount(userName);   
            Console.WriteLine("Вхід успішний");
        }
        else
            Console.WriteLine("Неправильний пароль");
    }
}
