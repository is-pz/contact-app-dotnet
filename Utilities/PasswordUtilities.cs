using contact_app.Data;
using System.Security.Cryptography;
using System.Text;

namespace contact_app.Utilities
{
    public class PasswordUtilities
    {

        private String EncodingString(string String)
        {
            byte[] StringToByte = Encoding.ASCII.GetBytes(String);
            var Md5 = MD5.Create();
            byte[] Md5String = Md5.ComputeHash(StringToByte);
            var Ascii = new ASCIIEncoding();
            var Md5Hash = Ascii.GetString(Md5String);

            return Md5Hash;
        }

        public String GetHashPassword(string Password)
        {
            string HashedPassword = EncodingString(Password);

            return HashedPassword;
        }

        public Boolean PasswordVerify(string Password, string PasswordSaved)
        {

            string hashedPassword = EncodingString(Password);

            return hashedPassword.Equals(PasswordSaved) ? true : false;
        }

    }
}
