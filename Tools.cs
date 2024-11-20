using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Widget
{
    public class Tools
    {
        public static string GenerateRandomString(int length)
        {
            // Define the characters that are allowed in this random string
            // You can modify this string to include any characters you want
            const string allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder builder = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                // Select a random character from the allowedChars string and append it to the builder
                char c = allowedChars[random.Next(allowedChars.Length)];
                builder.Append(c);
            }

            // Return the built string
            return builder.ToString();
        }
    }
}
