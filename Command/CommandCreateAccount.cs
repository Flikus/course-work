class CommandCreateAccount : ICommand
{
    public string NameCommand() { return "createAccount"; }
    public string DescriptionCommand() { return " - створити гравця"; }    


    
    PlayerService adminPlayer;
    public CommandCreateAccount(PlayerService adminPlayerObj)
    {
        adminPlayer = adminPlayerObj;
    }

    public void Command() {

        string userName;
        string password;
        string typeAccount;

        do{
            Console.Write("Введіть ім'я користувача: ");

            // Зчитуємо перший символ
            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: false); //intercept - вивести символ на екран
            if (keyInfo.Key == ConsoleKey.Escape)
                return;
            userName = keyInfo.KeyChar.ToString();
            userName += Console.ReadLine(); 

            if(adminPlayer.CheckExistAccount(userName))
                Console.WriteLine("Користувач з таким ім'ям вже існує");

        } while(userName.Count() < 1 || adminPlayer.CheckExistAccount(userName));



        PasswordHasher hash = new PasswordHasher();

        do
        { 
            Console.Write("Введіть пароль: ");

            // Зчитуємо перший символ
            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: false); //intercept - вивести символ на екран
            if (keyInfo.Key == ConsoleKey.Escape)
                return;
            password = keyInfo.KeyChar.ToString();
            password += Console.ReadLine();
            

        } while(password == null);
        
        
        do{
            Console.Write("Введіть тип акаунту(Standart, Pay, Winstreak): ");

            // Зчитуємо перший символ
            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: false); //intercept - вивести символ на екран
            if (keyInfo.Key == ConsoleKey.Escape)
                return;
            typeAccount = keyInfo.KeyChar.ToString();
            typeAccount += Console.ReadLine();  
        } while(!(typeAccount == "Standart" || typeAccount == "Pay" || typeAccount == "Winstreak"));

        adminPlayer.CreateAccont(userName, password, typeAccount);
        Console.Write("Акаунт успішно створений");
    }
}