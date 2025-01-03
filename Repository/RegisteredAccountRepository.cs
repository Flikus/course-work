class RegisteredAccountRepository : IRegisteredAccountRepository
{
    RegisteredAccount registeredAccountRepository;
    public RegisteredAccountRepository(RegisteredAccount registeredAccountRepositoryObj)
    {
        registeredAccountRepository = registeredAccountRepositoryObj;
    }

    public void WriteRegisteredAccount(string? userName)
    {
        registeredAccountRepository.NameAccount = userName;
    }

    public string? GetRegisteredAccount()
    {
        return registeredAccountRepository.NameAccount;
    }

    public void DeleteRegisteredAccount()
    {
        registeredAccountRepository.NameAccount = null;
    }
}
