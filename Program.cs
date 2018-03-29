/*
Name: Random Password
Course: PROG1783-18W-Sec1-IT Support Programming Fundamentals
Professor: Scanlan, H.
Number Student ID: 7679566
Student: Daniel Brazil
Date: March, 23, 2018
*/

using System;
using System.Text;

namespace BonusRandomPassword
{
    class Program
    {
        static void Main(string[] args)
        {
            string sAnswer = "Y";
            while (sAnswer.Trim().ToUpper() == "Y")
            {
                Console.Clear();
                WelcomeScreen();
                ShowResults();
                Console.WriteLine("Would you like to execute again? (Press [Y]es or [N]o)");
                sAnswer = Console.ReadLine();
            }

        }

        private static void WelcomeScreen()
        {
            Console.Clear();
            Console.WriteLine("Welcome the system to generate passwords!!!");
            Console.WriteLine("======================================================================================================");
            Console.WriteLine("The system to make a random password between 12 and 16 caracters.");
            Console.WriteLine("The password contains a mix of letters and numbers, and punctuation and a mix of cases with no spaces.");
            Console.WriteLine("The password must contain: ");
            Console.WriteLine("1 - More than 3 lower case letters;");
            Console.WriteLine("2 - More than 3 upper case letters;");
            Console.WriteLine("3 - More than 3 numbers;");
            Console.WriteLine("4 - At least the letter f or a");
            Console.WriteLine("======================================================================================================");
        }

        private static void ShowResults()
        {
            string s = string.Empty;
            int iCount = 0;
            int iResultRandom;
            bool bValidate = false;
            string sAnswer = string.Empty;
            Random rnd = new Random();

            iResultRandom = rnd.Next(12, 16);
            while (sAnswer.Trim().ToUpper() != "Y" && sAnswer.Trim().ToUpper() != "N")
            {
                Console.WriteLine("Would you like to see the attempts generated? (Press [Y]es or [N]o)");
                sAnswer = Console.ReadLine();
            }
            Console.WriteLine("======================================================================================================");
            Console.WriteLine("System that generates a password of {0} positions.", iResultRandom);
            Console.WriteLine("======================================================================================================");
            while (!bValidate)
            {
                s = CreatePassword(iResultRandom);
                if ((CountCaracteres(1, s) > 3) &&
                   (CountCaracteres(2, s) > 3) &&
                   (CountCaracteres(3, s) > 3) &&
                   (s.Contains("f") || s.Contains("a")))
                {
                    bValidate = true;
                }
                else if (sAnswer.Trim().ToUpper() == "Y")
                {
                    Console.WriteLine("This password was not valid = {0}", s);
                }

                iCount++;
            }
            Console.WriteLine("The system tried {0} times to be able to generate the password in the defined pattern", iCount);
            Console.WriteLine("The generated password is {0} ", s);
        }

        public static int CountCaracteres(int iType, string sText)
        {
            int iCount = 0;
            int iIsNumber;
            for (int i = 0; i <= sText.Length - 1; i++)
            {
                switch (iType)
                {
                    case 1://lowercase
                        if (sText.Substring(i, 1) == sText.Substring(i, 1).ToLower())
                            iCount++;
                        break;
                    case 2://uppercase
                        if (sText.Substring(i, 1) == sText.Substring(i, 1).ToUpper())
                            iCount++;
                        break;
                    case 3://numbers
                        if (int.TryParse(sText.Substring(i, 1), out iIsNumber))
                            iCount++;
                        break;
                }
            }

            return iCount;
        }

        public static string CreatePassword(int iLength)
        {
            const string sValid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890+-.*/,/?;:..<,^~]}{[´`-_=!@#$%¨&*()";
            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();
            while (sb.Length <= iLength)
            {
                sb.Append(sValid[rnd.Next(sValid.Length)]);
            }
            return sb.ToString();
        }
    }
}
