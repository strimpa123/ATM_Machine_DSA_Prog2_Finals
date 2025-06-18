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
            string admin_acc_path = $"{data_directory_path}/admin_accounts.csv";
            string reciepts_path = "Reciepts_Log";

            if (!Directory.Exists(data_directory_path))
                Directory.CreateDirectory(data_directory_path);
            if (!Directory.Exists(reciepts_path))
                Directory.CreateDirectory(reciepts_path);
            if (!File.Exists(accounts_path))
                File.AppendAllText(accounts_path, "Name,Account Number,PIN,Balance");
            if (!File.Exists(admin_acc_path))
                File.AppendAllText(admin_acc_path, "kian,sarah");

            bool authentication = true;
            bool admin = false;
            while (authentication)
            {
                Console.WriteLine("Insert Your Card (Path): ");
                string user_card_path = Console.ReadLine();

                
                string[] accounts = File.ReadAllLines(accounts_path);
                string[] account_info;

                if (user_card_path == "5426")
                {
                    string[] admins_account = File.ReadAllLines(admin_acc_path);
                    Console.WriteLine("Enter Account Name");
                    string admin_name = Console.ReadLine();
                    for (int i = 0; i < admins_account.Length; i++)
                    {
                        string[] admin_info = admins_account[i].Split(','); // [0]Account Names, [1] Passwords
                        if (admin_name == admin_info[0])
                        {
                            Console.WriteLine("Enter Password: ");
                            string admin_pass = Console.ReadLine();
                            if (admin_pass == admin_info[1])
                                admin = true;
                            else
                                Console.WriteLine("Wrong Password");
                        }
                        if (i + 1 >= admins_account.Length)
                            Console.WriteLine("Account Does not Exist");
                    }
                }
                else
                {
                    admin = false;
                    if (!File.Exists(user_card_path))
                        Console.WriteLine("Card Not Found!");
                    else
                    {
                        string[] user_card = File.ReadAllLines(user_card_path);
                        string[] user_card_info = user_card[1].Split(','); // [0]Account Number, [1]Firstname , [2]Lastname , [3]CVV ---(CARD FORMAT)
                        for (int i = 0; i < accounts.Length; i++)
                        {
                            account_info = accounts[i].Split(','); // [0]Name , [1]Account Number , [2]PIN , [3]Balance ---(ACCOUNT FORMAT)
                            if (user_card_info[0] == account_info[1])
                            {
                                Console.WriteLine("Enter Account PIN: ");
                                string user_card_pin = Console.ReadLine();
                                if (user_card_pin == account_info[2])
                                    break;
                                else
                                    Console.WriteLine("Wrong PIN! || Ejecting Card...");
                            }
                            if (i + 1 >= accounts.Length)
                                Console.WriteLine("Invalid Bank Account Card! || Ejecting Card...");
                        }
                    }
                }
            }
            if (admin) // Admin Menu
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Clear();
                Console.WriteLine("------([Administrator Menu])------");
            }
            if (!admin) // User Menu
            {
                Console.WriteLine("is user");
            }
        }
    }
}
