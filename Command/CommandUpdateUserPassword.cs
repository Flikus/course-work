class CommandUpdateUserPassword : ICommand
{
    public string NameCommand() { return "updatePassword"; }
    public string DescriptionCommand() { return "  - змінити пароль "; }


    PlayerService adminPlayer;
    RegisteredAccountService adminRegisteredAccount;
    PasswordHasher hash = new PasswordHasher();



    public CommandUpdateUserPassword(PlayerService adminPlayerObj, RegisteredAccountService adminRegisteredAccountObj)
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

        string password;
        string newPassword;

        bool truePassword;

        do { 
            Console.Write("Введіть пароль: ");

            // Зчитуємо перший символ
            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: false); //intercept - вивести символ на екран
            if (keyInfo.Key == ConsoleKey.Escape)
                return;
            password = keyInfo.KeyChar.ToString();
            password += Console.ReadLine();
            
            truePassword = hash.VerifyPassword(password, adminPlayer.CheckPlayerPassword(adminRegisteredAccount.GetRegisteredAccount()));
            if(!truePassword) 
                Console.WriteLine("Невірно введений парль");

        } while(password == null || !truePassword);
            
        do { 
            Console.Write("Введіть новий пароль: ");

            // Зчитуємо перший символ
            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: false); //intercept - вивести символ на екран
            if (keyInfo.Key == ConsoleKey.Escape)
                return;
            newPassword = keyInfo.KeyChar.ToString();
            newPassword += Console.ReadLine();
            
        } while(newPassword == null);
        
        
        adminPlayer.UpdateUserPassword(adminRegisteredAccount.GetRegisteredAccount(), newPassword); 
        Console.Write("пароль успішно змінено");
    }
}