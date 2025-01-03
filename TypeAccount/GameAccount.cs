class GameAccount 
{	
  	public string UserName {get; private set;}    	 	// Імя користувача
	public string Password {get; private set;}  		// Пароль
	public string TypeAccount {get; private set;}       // Тип акаунту
  	public int 	  CurrentRating {get; protected  set;}  // Рейтинг користувача
	public int 	  GamesCount {get; private set;}  		// Кількість зіграних партій
	protected List<PlayedGame> 	GameHistory; 			// Істворія ігор
	
	
	public GameAccount(string userName, string password, string typeAccount) {
		UserName = userName;
		Password = password;
		TypeAccount = typeAccount;
		CurrentRating = 100;
		GamesCount = 0;
		GameHistory = new List<PlayedGame>();
	}

	public void UpdateUserName(string userName)
    {
        UserName = userName;
    }

	public void UpdateUserPassword(string password)
	{
		Password = password;
	}

	public virtual void WinGame(string opponentName, Game game) {
		GameHistory.Add(new PlayedGame(opponentName, game.Rating, CurrentRating, "win", TypeAccount, game.TypeGame)); 
        GamesCount++;		
	}
	public virtual void LoseGame(string opponentName, Game game) {
		GameHistory.Add(new PlayedGame(opponentName, game.Rating, CurrentRating, "lose", TypeAccount, game.TypeGame));
        GamesCount++;		
	}

	public void GetStats() {
		Console.WriteLine("-----------------------------------------------------------------------------------------");
		Console.WriteLine("|   " + UserName + "  " + GamesCount + " ігор                                           |");
		Console.WriteLine("-----------------------------------------------------------------------------------------");
		if(GamesCount > 0) {
			Console.WriteLine("| індекс гри | Тип акунта | Рейтинг | Опонент | Зіграний рейтинг | Результат |  Тип гри |");
			for(int i = 0; i < GameHistory.Count; i++){		
				Console.Write("|{0,11:d10} |",GameHistory[i].GamrId);		
				Console.Write("{0,11} |",	  GameHistory[i].TypeAccount);			
				Console.Write("{0, 8} |",	  GameHistory[i].Rating);
				Console.Write("{0, 8} |",	  GameHistory[i].OpponentName);
				Console.Write("{0,17} |",	  GameHistory[i].GameRating);
				Console.Write("{0,10} |",	  GameHistory[i].Result);	
				Console.Write("{0, 9} |",	  GameHistory[i].TypeGame);

				Console.Write("\n");
			}
			Console.WriteLine("-----------------------------------------------------------------------------------------");
		}
	}
}