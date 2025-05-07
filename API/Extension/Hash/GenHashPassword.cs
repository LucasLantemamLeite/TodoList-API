namespace TodoList.Extension.Hash;
using System.Security.Cryptography;

public class GenPasswordHash
{

    private static byte[] GenSalt()
    {
        using (var rng = RandomNumberGenerator.Create())
        {
            byte[] salt = new byte[16];
            rng.GetBytes(salt);
            return salt;
        }
    }

    public static string GenHashWithSalt(string password)
    {
        byte[] salt = GenSalt();

        using (var rfc2898 = new Rfc2898DeriveBytes(password, salt, 1000))
        {
            byte[] hash = rfc2898.GetBytes(32);
            string hashBase64 = Convert.ToBase64String(hash);
            string saltBase64 = Convert.ToBase64String(salt);

            return $"{saltBase64}:{hashBase64}";
        }
    }
}