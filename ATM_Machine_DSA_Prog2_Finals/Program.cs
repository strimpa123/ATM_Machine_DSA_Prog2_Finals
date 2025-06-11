using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ATM_Machine_DSA_Prog2_Finals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string data_directory_path = "Account_Data";
            string accounts_path = $"{data_directory_path}/accounts.csv"; 
            string reciepts_path = "Reciepts_Log";

            if (!Directory.Exists(data_directory_path))
                Directory.CreateDirectory(data_directory_path);
            if (!Directory.Exists(reciepts_path))
                Directory.CreateDirectory(reciepts_path);
            if (!File.Exists(accounts_path))
                File.AppendAllText(accounts_path, "Name,Account Number,PIN,Balance");
                

            Console.WriteLine("Enter Your Account Number: ");
            string user_account_entry = Console.ReadLine();
            bool admin = false;
            string[] accounts = File.ReadAllLines(accounts_path);
            string[] account_info; // Format = [0]Name , [1]Account Number , [2]PIN , [3]Balance

            if (user_account_entry == "5426")
                admin = true;
            else
            {
                admin = false;
                for (int i = 1; i < accounts.Length; i++)
                {
                    account_info = accounts[i].Split(',');
                    if (user_account_entry == account_info[1]) 
                        break;
                }
            }
                

            if (admin) // Admin Access
            {
                Console.WriteLine("is admin");
            }
            if (!admin) // User Access
            {
                Console.WriteLine("is user");
            }
        }
    }
}
