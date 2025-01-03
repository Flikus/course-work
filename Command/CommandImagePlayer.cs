class CommandImagePlayer : ICommand
{
    public string NameCommand() { return "imagePlayer"; }
    public string DescriptionCommand() { return "  - вивести данні гравця"; }


    PlayerService adminPlayer;
    public CommandImagePlayer(PlayerService adminPlayerObj)
    {
        adminPlayer = adminPlayerObj;
    }

    public void Command() {
        string userName;

        if(adminPlayer.AccountCount() < 1) {
            Console.WriteLine("Немає зареєстрованих акаунтів\n");
            return;
        }


        do{
            Console.Write("Введіть ім'я користувача: ");

            // Зчитуємо перший символ
            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: false); //intercept - вивести символ на екран
            if (keyInfo.Key == ConsoleKey.Escape)
                return;
            userName = keyInfo.KeyChar.ToString();
            userName += Console.ReadLine(); 

            if(!adminPlayer.CheckExistAccount(userName))
                Console.WriteLine("Користувач з таким ім'ям не існує");

        } while(!adminPlayer.CheckExistAccount(userName));

        adminPlayer.OutputAccountById(userName); 
    }
}