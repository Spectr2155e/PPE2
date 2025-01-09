using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WindowsFormsApp1.Utils
{
    internal class Utils
    {

        public static String sha256_hash(String value)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }

        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static bool IsValidMail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static int randomValue(int min, int max)
        {
            Random rnd = new Random();
            return rnd.Next(min, max);
        }

        public static void sendAnEmailConfirmation(string mail, int code)
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("bekhtiricharderwann@gmail.com", "jbet ahdm mwzg fyaf"),
                EnableSsl = true
            };
            client.Send("bekhtiricharderwann@gmail.com", mail, "test", "Votre code est celui-ci "+code);
            Console.WriteLine("Sent");
            Console.ReadLine();
        }

    }
}
