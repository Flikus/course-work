interface IRegisteredAccountRepository
{
    public void WriteRegisteredAccount(string userName);
    public string? GetRegisteredAccount();
    public void DeleteRegisteredAccount();
}