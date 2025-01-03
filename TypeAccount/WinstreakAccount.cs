class WinstreakAccount : GameAccount
{   
    static int winstreak = 0; //рахунок виграшноъ смуги
    public WinstreakAccount (string userName, string password) : base(userName, password, "winstreak") {}

    public override void WinGame(string OpponentName, Game game) {
        winstreak++;

        if(winstreak > 2)
            CurrentRating += game.WinCalculate() * 2;
        else
            CurrentRating += game.WinCalculate();

        base.WinGame(OpponentName, game);
    }

	public override void LoseGame(string OpponentName, Game game) {
        if(CurrentRating - game.LoseCalculate() <= 0) //якщо рейтинг стає меншим за 1
            CurrentRating = 1;
        else
            CurrentRating -= game.LoseCalculate();
            
        base.LoseGame(OpponentName, game);
        winstreak = 0;
	}
}