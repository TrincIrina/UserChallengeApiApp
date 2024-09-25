using System.Security.Cryptography;
using System.Text;

namespace UserChallengeApiApp.Crypto
{
    public class MD5Encoder : IEncoder
    {
        public string Encode(string data)
        {
            MD5 md5 = MD5.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            byte[] hashBytes = md5.ComputeHash(bytes);
            return Convert.ToHexString(hashBytes);
        }
    }
}
