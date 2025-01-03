abstract class Game
{    
    public string TypeGame { get; private set; }
    public int 	  Rating   { get; private set; }

    public Game (string typeGame, int rating) {
        if(rating < 0) {
            Console.WriteLine("Помилка: Рейтинг не може бути від'ємним");
            return;
        }
        TypeGame = typeGame;
        Rating = rating;
    }

    public abstract int WinCalculate();
    public abstract int LoseCalculate();
}