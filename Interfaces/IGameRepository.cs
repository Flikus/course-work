interface IGameRepository 
{
    public void CreateGame(string typeGame, int rating);  // Додати кімнату для гри до бази даних
    int ReadGame(int value);                              // Отримати загальну кількість кімнат(ігор)
    int ReadGame(Game room);                              // Отримати індекс кімнати(гри) 
    Game ReadRoom(int index);                             // Отримати кімнату(гру) по індексу 
    public void DeleteGame(int index);                    // Видалити кімнату(гру) з бази даних
}