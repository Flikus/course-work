class PayAccount : GameAccount
{   
    public PayAccount (string userName, string password) : base(userName, password, "pay") {}

    public override void WinGame(string opponentName, Game game) {
        CurrentRating += game.WinCalculate() * 2;
        base.WinGame(opponentName, game);
    }

	public override void LoseGame(string opponentName, Game game) {
        if(CurrentRating - game.LoseCalculate() / 2 <= 0) //якщо рейтинг стає меншим за 1
            CurrentRating = 1;
        else
            CurrentRating -= game.LoseCalculate() / 2;
            
        base.LoseGame(opponentName, game);
    }
}