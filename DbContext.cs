class DbContext
{
    public List<GameAccount> Players { get; private set;} // Список гравців   
    public List<Game>  Games         { get; private set;} // Список ігор

    // Ініціалізація бази даних
    public DbContext()
    {
        Players = new List<GameAccount>();
        Games = new List<Game>();
    }
}
