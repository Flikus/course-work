class PlayerService : IPlayersService
{   
    PlayerRepository playerRepository;
    PasswordHasher hash = new PasswordHasher();

    public PlayerService(DbContext dbContextObj)
    {
        playerRepository = new PlayerRepository(dbContextObj);
    } 


    //створити акаунт
    public void CreateAccont(string userName, string password, string typeAccount)
    {
        if(playerRepository.ReadPlayer(userName) >= 0){
            Console.Write("Користувач з таким іменем вже існує\n");           
        }
        else
            playerRepository.CreatePlayer(userName, hash.HashPassword(password), typeAccount);
    }



    //перевірити чи існує акаунт з таким ім'ям
    public bool CheckExistAccount(string userName)
    {
        if(playerRepository.ReadPlayer(userName) >= 0)
            return true;
        else 
            return false;
    }

    //отримати кількість акаунтів
    public int AccountCount()
    {
        return playerRepository.ReadPlayer(1);
    }

    //перевірити пароль користувача
    public string CheckPlayerPassword(string userName)
    {
        GameAccount temp = playerRepository.ReadAccount(userName);

        if(temp != null) 
            return temp.Password;            
        else 
            Console.WriteLine("Акаунту не існує!!!");
            
        return null;
    }




    //вивід інформації про гравця
    private void OutputPlayerById(int index)
    {	
        GameAccount account = playerRepository.ReadAccount(index);
        if(account.UserName == null)
            Console.Write("Користувача не знайдено\n");

        else{
            Console.Write("|{0,7:d3} |", index);
            Console.Write("{0, 8} |" , account.UserName);		
            Console.Write("{0,11} |" , account.TypeAccount);			
            Console.Write("{0, 8} |" , account.CurrentRating);
            Console.Write("{0, 15} |", account.GamesCount);
            Console.Write("\n");            
        }
    }

    //вивід гравця за ід
    public void OutputAccountById(string userName)
    {
        int index = playerRepository.ReadPlayer(userName);
        if(index >= 0) {
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("| індекс | гравець | тип акунта | рейтинг | Кількість ігор |");

            OutputPlayerById(index);

            Console.WriteLine("------------------------------------------------------------");
            Console.Write("\n");
        }
    }

    //вивести всі акаунти
    public void OutputAllAccount()
    {   
        if(playerRepository.ReadPlayer(1) >= 0) {
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("| індекс | гравець | тип акунта | рейтинг | Кількість ігор |");

            for(int i = 0; i < playerRepository.ReadPlayer(1); i++)
                OutputPlayerById(i);

            Console.WriteLine("------------------------------------------------------------");
            Console.Write("\n");
        }
        else
            Console.WriteLine("Спочатку додайте користувачів");
    }




    //вивести ігри які зіграв гравець
    public void OutputPlayerGamesByPlayerId(string userName)
    {
        playerRepository.ReadPlayerGamesByPlayerId(userName);
    }



    //отримати акаунт гравця
    public GameAccount GetAccount(string userName)
    {
        GameAccount temp = playerRepository.ReadAccount(userName);
        if(temp == null) {
            Console.Write("Користувача не знайдено\n");
            return null;
        }
        return temp;
    }

    public void UpdateUserName(string userName, string newUserName)
    {
        if(!CheckExistAccount(newUserName))
            playerRepository.UpdateUserName(userName, newUserName);
    }

    public void UpdateUserPassword(string userName, string newPassword)
    {
        if(CheckExistAccount(userName))
            playerRepository.UpdateUserPassword(userName, hash.HashPassword(newPassword));
    }


    public void DeletePlayer(string userName) 
    {
        if(CheckExistAccount(userName)) 
            playerRepository.DeletePlayer(userName);
        else
            Console.Write("Користувача з таким іменем не знайдено\n");        
    }
 
}