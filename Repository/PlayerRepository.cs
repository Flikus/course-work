class PlayerRepository : IPlayerRepository
{
    DbContext dbContext;

    public PlayerRepository(DbContext dbContextObj)
    {
        dbContext = dbContextObj;
    }

    // Додати гравця до бази даних
    public void CreatePlayer(string userName, string password, string typeAccount)
    {   
        switch(typeAccount)
        {
        case "Standart" : dbContext.Players.Add(new StandartAccount(userName, password));  break;
        case "Pay"      : dbContext.Players.Add(new PayAccount(userName, password));       break;
        case "Winstreak": dbContext.Players.Add(new WinstreakAccount(userName, password)); break;
        default: Console.Write("Неіснуючий тип акаунту\n");                                break;
        }
    }



    // Отримати загальну кількість гравців
    public int ReadPlayer(int value)
    {
        if(value == 1)
            return dbContext.Players.Count();
        return -1;
    }



    // Отримати індекс гравця за іменем
    public int ReadPlayer(string userName)
    {
        return dbContext.Players.FindIndex(p => p.UserName == userName);
    }

    // Отримати гравця за ім'ям
    public GameAccount ReadAccount(string userName)
    {
        int index = ReadPlayer(userName);
        if(index < 0)
            return null;
        else
            return ReadAccount(index);
    }

    // Отримати гравця за індексом
    public GameAccount ReadAccount(int ind)
    {   
        if(ind < 0 || ind >= ReadPlayer(1)) 
            return null;
        else
            return dbContext.Players[ind];
    }


    public void ReadPlayerGamesByPlayerId(string userName)
    {
        if(ReadPlayer(userName) >= 0)
            ReadAccount(userName).GetStats(); 
    }




    public void UpdateUserName(string userName, string newUserName)
    {
        ReadAccount(userName).UpdateUserName(newUserName);
    }

    public void UpdateUserPassword(string userName, string newPassword)
    {
        ReadAccount(userName).UpdateUserPassword(newPassword);
    }




    // Видалити гравця з бази даних
    public void DeletePlayer(string userName)
    {   
        dbContext.Players.Remove(ReadAccount(userName));
    }
}