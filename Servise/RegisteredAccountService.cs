class RegisteredAccountService
{
    RegisteredAccountRepository registeredAccountRepository;

    public RegisteredAccountService(RegisteredAccount registeredAccount)
    {
        registeredAccountRepository = new RegisteredAccountRepository(registeredAccount);
    } 

    public bool CheckRegisteredAccount()
    {
        if(registeredAccountRepository.GetRegisteredAccount() != null)
            return true;
        else
            return false;
    }

    public string? GetRegisteredAccount()
    {
        return registeredAccountRepository.GetRegisteredAccount();
    }

    public void WriteRegisteredAccount(string? userName)
    {
        registeredAccountRepository.WriteRegisteredAccount(userName);
    }

    public void DeleteRegisteredAccount()
    {
        if(CheckRegisteredAccount())
            Console.WriteLine("Немає зареєстрованих акаунтів");
        else
            registeredAccountRepository.DeleteRegisteredAccount();
    }
}