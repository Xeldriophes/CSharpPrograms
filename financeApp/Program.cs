using System;
using System.IO;

namespace financeApp
{
    class Program
    {
        // Initialisation
        public static int accBalance = 0;

        static void Main(string[] args)
        {
            // Calling the menu method
            Menu();
        }
        static void Menu()
        {
            // Intro Information
            Console.WriteLine(" ------------- ");
            Console.WriteLine(" Money Tracker ");
            Console.WriteLine(" ------------- ");

            // Options List
            Console.WriteLine(" 1. Set initial balance ");
            Console.WriteLine(" 2. Add money to balance ");
            Console.WriteLine(" 3. Subtract money from balance ");
            Console.WriteLine(" 4. Add recurring balance ");
            Console.WriteLine(" 5. Check your balance ");
            Console.WriteLine(" 6. Save current balance ");
            Console.WriteLine(" 7. Load previous balance ");
            Console.WriteLine(" 8. Exit the program ");

            // Capture User choice
            string choices = Console.ReadLine();

            // Check it can be parsed
            if (int.TryParse(choices, out int choice))
            {
                // Controls which method gets activated based on case
                switch (choice)
                {
                    case 1:
                        Set_balance();
                        break;
                    case 2:
                        Add_money();
                        break;
                    case 3:
                        Subtract_money();
                        break;
                    case 4:
                        Recurring_balance();
                        break;
                    case 5:
                        Check_balance();
                        break;
                    case 6:
                        Save_balance();
                        break;
                    case 7:
                        Load_balance();
                        break;
                    case 8:
                        Environment.Exit(1);
                        break;
                }
            }
            Menu();
        }

        private static void Load_balance()
        {
            if (!File.Exists("C:\\balance.txt"))
            {
                StreamWriter sw = new StreamWriter("C:\\balance.txt");
                //sw.WriteLine("This is still running");
                sw.Close();
            }

            StreamReader sr = new StreamReader("C:\\balance.txt");
            string prevBalstr = sr.ReadLine();

            while (prevBalstr != null)
            {
                int prevBalInt = int.Parse(prevBalstr);
                accBalance = prevBalInt;
                sr.Close();
                Menu();
            }
            //Menu();
        }

        private static void Save_balance()
        {
            if (File.Exists("C:\\balance.txt"))
            {
                StreamWriter bal = new StreamWriter("C:\\balance.txt");
                bal.WriteLine(accBalance);
                bal.Close();
            }
            Menu();
        }

        private static void Set_balance()
        {
            Console.Write(" Enter your initial amount of money in GBP: £");
            string balance = Console.ReadLine();
            // Check what's entered by user can be converted to an int. if not displays error
            if (int.TryParse(balance, out int sBalance))
            {
                Console.WriteLine($"Your balance added is {sBalance}");
                accBalance += sBalance;
                Console.WriteLine("Clearing Screen... (press a key to continue)");
                Console.ReadLine();
                Console.Clear();
                Menu();
            }
            // Used to display an error message
            else
            {
                Console.WriteLine(" Invalid Data Type. Please use numbers only. (Error Code 1) ");
                Menu();
            }
        }
        private static void Add_money()
        {
            Console.Write(" Enter the money to be deposited: £");
            string balance = Console.ReadLine();
            // Check what's entered by user can be converted to an int. if not displays error
            if (int.TryParse(balance, out int aBalance) && aBalance >= 0)
            {
                Console.WriteLine($"You added {aBalance} to your account");
                accBalance += aBalance;
                Console.WriteLine("Clearing Screen... (press a key to continue)");
                Console.ReadLine();
                Console.Clear();
                Menu();
            }
            // Used to display an error message
            else
            {
                Console.WriteLine(" Invalid Data Type. Please use numbers only. (Error Code 1) ");
                Menu();
            }
        }
        private static void Recurring_balance()
        {
            Console.Write(" Enter the money to be taken out per month: £");
            string balance = Console.ReadLine();
            // Check what's entered by user can be converted to an int. if not displays error
            if (int.TryParse(balance, out int rBalance))
            {
                Console.Write(" Enter how many months this is gonna be used per year: ");
                string month = Console.ReadLine();
                int.TryParse(month, out int rMonth);
                rBalance = rBalance * rMonth;
                accBalance -= rBalance;
                Console.WriteLine("Clearing Screen... (press a key to continue)");
                Console.ReadLine();
                Console.Clear();
                Menu();
            }
            // Used to display an error message
            else
            {
                Console.WriteLine(" Invalid Data Type. Please use numbers only. (Error Code 1) ");
                Menu();
            }
        }

        private static void Subtract_money()
        {
            int intBalance = accBalance;
            Console.Write(" Enter the money to be removed: £");
            string balance = Console.ReadLine();
            // Check what's entered by user can be converted to an int. if not displays error
            if (int.TryParse(balance, out int tBalance))
            {
                accBalance -= tBalance;
                if (accBalance < 0)
                {
                    Console.WriteLine("Are you willing to continue even if this means you will owe money?");
                    var ans = Console.ReadLine();
                    ans = ans.ToUpper();
                    if (ans == "YES")
                    {
                        Console.WriteLine($"You removed {tBalance} from your account");
                        double remainder = tBalance + accBalance;
                        Console.WriteLine("You now owe £" + remainder);
                    }
                    else
                    {
                        accBalance = 0;
                        Console.WriteLine("You have refused the payment. Please contact the original charger ");
                        accBalance += intBalance;
                    }
                }
                Console.WriteLine("Clearing Screen... (press a key to continue)");
                Console.ReadLine();
                Console.Clear();
                Menu();
            }
            // Used to display an error message
            else
            {
                Console.WriteLine(" Invalid Data Type. Please use numbers only. (Error Code 1) ");
                Menu();
            }
        }

        private static void Check_balance()
        {
            Console.WriteLine($"Your balance is £{accBalance}");
            Console.WriteLine("Clearing Screen... (press a key to continue)");
            Console.ReadLine();
            Console.Clear();
            Menu();
        }
    }
}