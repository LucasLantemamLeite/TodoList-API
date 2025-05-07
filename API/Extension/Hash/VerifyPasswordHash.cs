using System.Security.Cryptography;

namespace TodoList.Extension.Hash;

public class VerifyPasswordHash
{
    public static bool VerifyPasswordHashWithSalt(string password, string storedSaltHash)
    {

        var parts = storedSaltHash.Split(":");
        string saltBase64 = parts[0];
        string hashBase64 = parts[1];

        byte[] salt = Convert.FromBase64String(saltBase64);
        byte[] storedHash = Convert.FromBase64String(hashBase64);

        using (var rfc2898 = new Rfc2898DeriveBytes(password, salt, 1000))
        {
            byte[] passowordHash = rfc2898.GetBytes(32);
            return CompareByteArray(storedHash, passowordHash);
        }
    }

    private static bool CompareByteArray(byte[] array1, byte[] array2)
    {
        if (array1.Length != array2.Length)
            return false;

        for (int i = 0; i < array1.Length; i++)
        {
            if (array1[i] != array2[i])
                return false;
        }

        return true;
    }
}