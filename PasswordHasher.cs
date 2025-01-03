using System.Security.Cryptography;
using System.Text;

public class PasswordHasher
{
    public string? HashPassword(string password)
    {
        if (string.IsNullOrEmpty(password)){
            Console.WriteLine("Пароль не може бути порожнім або null");
            return null;      
        }

        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = sha256.ComputeHash(passwordBytes);

            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        string? computedHash = HashPassword(password);
        return string.Equals(computedHash, hashedPassword, StringComparison.OrdinalIgnoreCase);
    }
}
