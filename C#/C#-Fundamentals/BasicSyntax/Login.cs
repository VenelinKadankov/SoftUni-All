using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace Login
{
    class Login
    {
        static void Main(string[] args)
        {
            string userName = Console.ReadLine();
            string loginTry = Console.ReadLine();
            int counter = 0;

            static string Reverse(string userName)
            { 
            char[] userNameArray = userName.ToCharArray();
            Array.Reverse(userNameArray);
            return new string(userNameArray);
            }

            string pass = Reverse(userName);

            while(loginTry != pass)
            {

                counter++;

                if(counter >= 4)
                {
                    Console.WriteLine($"User {userName} blocked!");
                    break;
                }

                Console.WriteLine("Incorrect password. Try again.");

                loginTry = Console.ReadLine();

                if(loginTry == pass)
                {
                    Console.WriteLine($"User {userName} logged in.");
                }
            }

        }
    }
}
