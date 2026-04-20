using System.Security.Cryptography;
using System.Text;

namespace ProjectManagementSystem.Utils;

public static class EncryptionUtils
{
    private static readonly string SecretKey = "ed47659349e669994b51285e4fcf59be";
    
    public static  string Encrypt(string clearText)
    {
        using var aes = Aes.Create();
        aes.Key = Encoding.UTF8.GetBytes(SecretKey);
        aes.GenerateIV();

        using var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
        using var ms = new MemoryStream();
        
        ms.Write(aes.IV, 0, aes.IV.Length);
        
        using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
        using (var sw = new StreamWriter(cs)) sw.Write(clearText);

        return Convert.ToBase64String(ms.ToArray());
    }
    
    public static string Decrypt(string cipherText)
    {
        byte[] fullCipher = Convert.FromBase64String(cipherText);

        using var aes = Aes.Create();
        aes.Key = Encoding.UTF8.GetBytes(SecretKey);

        using var ms = new MemoryStream(fullCipher);
        var iv = new byte[aes.BlockSize / 8];
        ms.ReadExactly(iv, 0, iv.Length);
        aes.IV = iv;

        using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
        using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
        using var sr = new StreamReader(cs);
        
        return sr.ReadToEnd();
    }
}
