using contact_app.Data;
using System.Security.Cryptography;
using System.Text;

namespace contact_app.Utilities
{
    public class PasswordUtilities
    {
        public String GetHashPassword(string Password)
        {
            byte[] passwordToByte = Encoding.ASCII.GetBytes(Password);
            var md5 = MD5.Create();
            byte[] md5Password = md5.ComputeHash(passwordToByte);
            var ascii = new ASCIIEncoding();
            var hashedPassword = ascii.GetString(md5Password);

            return hashedPassword;
        }

        public Boolean PasswordVerify(string Password, string PasswordSaved)
        {

            byte[] passwordToByte = Encoding.ASCII.GetBytes(Password);
            var md5 = MD5.Create();
            byte[] md5Password = md5.ComputeHash(passwordToByte);
            var ascii = new ASCIIEncoding();
            string hashedPassword = ascii.GetString(md5Password);

            return hashedPassword.Equals(PasswordSaved) ? true : false;
        }

    }
}
