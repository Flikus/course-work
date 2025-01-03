class StandartAccount : GameAccount
{   
    public StandartAccount (string userName, string password) : base(userName, password, "standart") {}

    public override void WinGame(string opponentName, Game game) {
        CurrentRating += game.WinCalculate();
        base.WinGame(opponentName, game);
    }

	public override void LoseGame(string opponentName, Game game) {

        if(CurrentRating - game.LoseCalculate() <= 0) //якщо рейтинг стає меншим за 1
            CurrentRating = 1;
        else
            CurrentRating -= game.LoseCalculate();
        
        base.LoseGame(opponentName, game);
	}
}