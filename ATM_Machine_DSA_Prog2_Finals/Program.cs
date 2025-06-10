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
                File.Create(accounts_path);
        }
    }
}
