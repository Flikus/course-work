interface IRegisteredAccountService
{
    public bool CheckRegisteredAccount();
    public string? GetRegisteredAccount();
    public void WriteRegisteredAccount(string userName);
    public void DeleteRegisteredAccount();
}