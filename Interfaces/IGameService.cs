interface IGameService
{
    Game CreateGame(string typeGame, int rating);
    int GameCount();
    void OutputGameById(Game room);
    void OutputAllGame();
    Game GetGame(int index);
    public void DeleteGame(int index);

}