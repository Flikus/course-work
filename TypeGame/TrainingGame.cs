class TrainingGame : Game 
{
    public TrainingGame(string typeGame) : base(typeGame, 0) {}
    public override int WinCalculate() {
        return 0;
    }
    public override int LoseCalculate() {
        return 0;
    }
}