
class StandartGame : Game 
{
    public StandartGame (string typeGame, int rating) : base(typeGame, rating) {}
    public override int WinCalculate() {
        return Rating;
    }
    public override int LoseCalculate() {
        return Rating;
    }
}