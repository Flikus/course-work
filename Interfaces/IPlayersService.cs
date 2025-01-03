interface IPlayersService 
{
    void CreateAccont(string userName, string password, string TypeAccount); //створити акаунт
    public bool CheckExistAccount(string userName);                          //перевірити чи існує акаунт з таким ім'ям
    public int AccountCount();                                               //отримати кількість акаунтів

    void OutputAccountById(string userName);                                 //вивід гравця за ід
    void OutputAllAccount();                                                 //вивести всі акаунти
    void OutputPlayerGamesByPlayerId(string userName);                       //вивести ігри якиі зіграв гравець

    GameAccount GetAccount(string userName);                                 //отримати акаунт гравця

    public void UpdateUserName(string userName, string newUserName);         //змінити ім'я користувача
    public void UpdateUserPassword(string userName, string newPassword);     //змінити пароль користувача

    public void DeletePlayer(string userName);                               //видалити користувача
}