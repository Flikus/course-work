class OneriskGame : Game
{
    public OneriskGame(string typeGame, int rating) : base(typeGame, rating) {}
    public override int WinCalculate() {
        return Rating * 2;
    }
    public override int LoseCalculate() {
        return 0;
    }
}