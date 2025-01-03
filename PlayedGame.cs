class PlayedGame 
{
    private static int gameId = 0;

	public string TypeAccount  {get; private set;} //тип акаунту
    public string TypeGame     {get; private set;} //тип гри
    public string OpponentName {get; private set;} //ім'я опнента
    public int    GameRating   {get; private set;} //рейтинг на який грають
    public int    Rating       {get; private set;} //рейтинг гравця
    public string Result       {get; private set;} //результат гри
    public int    GamrId       {get; private set;} //ід гри


    public PlayedGame(string opponentName, int gameRating , int rating, string result, string typeAccount, string typeGame) {
        GamrId       = gameId++;
        TypeAccount  = typeAccount;
        Rating       = rating;        
        OpponentName = opponentName;
        GameRating   = gameRating; 
        Result       = result;       
        TypeGame     = typeGame;
    }
}