class GameService
{
    GameRepository gameRepository;
    public GameService(DbContext dbContextObj)
    {
        gameRepository = new GameRepository(dbContextObj);
    }


    public void CreateGame(string typeGame, int rating)
    {
        gameRepository.CreateGame(typeGame, rating);
    }
    
    public bool CheckExistGame(int index)
    {
        if(index >= 0 && index < GameCount())
            return true;
        else
            return false;
    }


    public int GameCount()
    {
        return gameRepository.ReadGame(1);
    }

    private void OutputRoomById(int index)
    {	
        Console.Write("|{0,7:d3} |", index);
		Console.Write("{0, 8} |", gameRepository.ReadRoom(index).TypeGame);		
		Console.Write("{0,8} |" , gameRepository.ReadRoom(index).Rating);		
		Console.Write("\n");
    }

    public void OutputGameById(Game room)
    {
        int index = gameRepository.ReadGame(room);
        if(index >= 0) {
            Console.WriteLine("------------------------------");
            Console.WriteLine("| індекс | тип гри | рейтинг |");

            OutputRoomById(index);

            Console.WriteLine("------------------------------");
            Console.Write("\n");
        }
    }

    public void OutputAllGame()
    {   
        Console.WriteLine("------------------------------");
		Console.WriteLine("| індекс | тип гри | рейтинг |");

        for(int i = 0; i < gameRepository.ReadGame(1); i++)
            OutputRoomById(i);

        Console.WriteLine("------------------------------");
        Console.Write("\n");
    }

    public Game GetGame(int index)
    {
        return gameRepository.ReadRoom(index);
    }

    public void DeleteGame(int index)
    {   
        if(CheckExistGame(index)) 
            gameRepository.DeleteGame(index);
        else
            Console.Write("Гру з таким індексом не знайдено\n");
    }
}