// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Utility.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace DataStructure
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    /// <summary>
    /// Utility is class hold all method which are reuseability
    /// </summary>
    class Utility
    {
        /// <summary>
        /// Reads the file.
        /// </summary>
        /// <param name="FileName">Name of the file.</param>
        /// <returns></returns>
        public string ReadFile(string FileName)
        {
            string st = "";
            try
            {
                StreamReader sr = new StreamReader(FileName);
                string str = sr.ReadLine();
                
                // To read the whole file line by line 
                while (str != null)
                {
                    st = str + st;
                    str = sr.ReadLine();
                }
                sr.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return st;
        }
        /// <summary>
        /// Inputs the string.
        /// </summary>
        /// <returns></returns>
        public string InputString()
        {
            return Console.ReadLine();
        }
        /// <summary>
        /// Inputs the integer.
        /// </summary>
        /// <returns></returns>
        public int InputInteger()
        {
            return Convert.ToInt32(Console.ReadLine());
        }
        /// <summary>
        /// Writes the in file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="line">The line.</param>
        /// <returns></returns>
        public bool WriteInFile(string fileName,string line)
        {
            try
            {
                StreamWriter sw = new StreamWriter(fileName);
                sw.Write(line);
                sw.Flush();
                sw.Close();
                return true;
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }
        /// <summary>
        /// Primes the specified n.
        /// </summary>
        /// <param name="n">The n.</param>
        /// <returns></returns>
        public bool Prime(int n)
        {
            for(int j=2;j<=n/2;j++)
            {
                if(n%j==0)
                {
                    return false;
                }
                
            }
            return true;
        }
        /// <summary>
        /// Anagrams the specified n1.
        /// </summary>
        /// <param name="n1">The n1.</param>
        /// <param name="n2">The n2.</param>
        /// <returns></returns>
        public bool Anagram(int n1, int n2)
        {
            int[] n1count = Count(n1);
            int[] n2count = Count(n2);
            for (int i = 0; i < n2count.Length; i++)
            {
                if (n1count[i] != n2count[i])
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Counts the specified n.
        /// </summary>
        /// <param name="n">The n.</param>
        /// <returns></returns>
        public int[] Count(int n)
        {
            int[] count = new int[10];
            int temp = n;
            while (temp != 0)
            {
                int r = temp % 10;
                count[r]++;
                temp = temp / 10;
            }
            return count;
        }
        /// <summary>
        /// Deposites the cash.
        /// </summary>
        /// <param name="bankdata">The bankdata.</param>
        /// <returns></returns>
        public int DepositeCash(BankingCashCounter bankdata)
        {
            int amount;
            Console.WriteLine("Enter the Amount You Want Deposite:");
            Console.WriteLine("Note:Amount should Be greater then zero");
            amount = InputInteger();
            if(amount>0)
            {
                BankingCashCounter.InitialAmount = BankingCashCounter.InitialAmount + amount;
                BankingCashCounter.DepositeAmount = BankingCashCounter.DepositeAmount + amount;
                Console.WriteLine("Transaction Successfull.");
            }
            else
            {
                Console.WriteLine("Transaction Failed:");
                Console.WriteLine("Amount Should Be Greater then Zero");
                return -1;
            }
            return BankingCashCounter.InitialAmount;
        }
        /// <summary>
        /// Withes the drawal cash.
        /// </summary>
        /// <param name="bankdata">The bankdata.</param>
        /// <returns></returns>
        public int WithDrawalCash(BankingCashCounter bankdata)
        {
            int amount;
            Console.WriteLine("Available Bank Cash Balance is: " + BankingCashCounter.InitialAmount);
            Console.WriteLine("Enter the Amount For Withdraw");
            amount = InputInteger();
            if(amount<BankingCashCounter.InitialAmount)
            {
                BankingCashCounter.InitialAmount = BankingCashCounter.InitialAmount - amount;
                BankingCashCounter.WithdrawAmount = BankingCashCounter.WithdrawAmount + amount;
                Console.WriteLine("Transaction Suceessfull");
                Console.WriteLine("Please Collect your Cash");
            }
            else
            {
                Console.WriteLine("Enter the Amount Equal OR Less the Available BAlance");
                return -1;
            }
            return BankingCashCounter.InitialAmount;
        }
    }
}