using System.Security.Cryptography;
using System.Text;

namespace Infra.Data.Encode;

public static class Password
{
    public static string EncodePassword(string password)
    {
        byte[] bytes   = Encoding.Unicode.GetBytes(password);
        byte[] inArray = HashAlgorithm.Create("SHA1").ComputeHash(bytes);
        return Convert.ToBase64String(inArray);
    }
}