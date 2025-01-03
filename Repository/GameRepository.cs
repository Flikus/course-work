class GameRepository : IGameRepository
{
    DbContext dbContext;
    static FabricGame fabric = new FabricGame();

    public GameRepository(DbContext dbContextObj)
    {
        dbContext = dbContextObj;
    }



    // Додати кімнату для гри до бази даних
    public void CreateGame(string typeGame, int rating)
    {          
        if(dbContext.Games.FindIndex(g => (g.TypeGame == typeGame) && (g.Rating == rating)) >= 0) 
            Console.Write("Така гра вже існує\n"); 
        else
        {
            Game temp = fabric.CreateGame(typeGame, rating);
            if(temp != null)
                dbContext.Games.Add(temp);
        }
    }


    // Отримати загальну кількість кімнат(ігор)
    public int ReadGame(int value)
    {
        if(value == 1)
            return dbContext.Games.Count();
        return -1;
    }



    // Отримати індекс кімнати(гри)
    public int ReadGame(Game room)
    {   
        int index = dbContext.Games.IndexOf(room);
        if(index < 0) 
            Console.Write("Такої гри не існує\n"); 

       return index;
    } 

 

    // Отримати кімнату(гру)
    public Game ReadRoom(int index)
    {
        if(index < 0 || index > ReadGame(1)) {
            Console.Write("Такої гри не існує\n"); 
            return new StandartGame(null, -1);
        }
        return dbContext.Games[index];
    }




    // Видалити кімнату(гру) з бази даних
    public void DeleteGame(int index)
    {   
        dbContext.Games.Remove(ReadRoom(index));
    }
}