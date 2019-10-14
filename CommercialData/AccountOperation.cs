// --------------------------------------------------------------------------------------------------------------------
// <copyright file=AccountOperation.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace OOPS.CommercialData
{ 
    using System;
    using System.Collections.Generic;
    using System.Text;
    /// <summary>
    /// CommercialInterface is a inteface which hold the methods
    /// </summary>
    interface CommercialInterface
    {
        void DisplayStock();
        void DisplayAccount();
        void Buy();
        void Sell();
    }
    /// <summary>
    /// AccountOperation is definig all the method which are declare in the intefcae by inherting the property of inteface
    /// </summary>
    /// <seealso cref="OOPS.CommercialData.CommercialInterface" />
    class AccountOperation :CommercialInterface
    {
        /// <summary>
        /// Displays the stock.
        /// </summary>
        public void DisplayStock()
        {
            NewAccount newAccount = JsonRead.JsonReadFile();
            ////Convert all data into the list type
            List<AccountModel> accountModels = newAccount.AccountList;
            double sum = 0;
            foreach (var account in accountModels)
            {
                Console.WriteLine("");
                Console.WriteLine("Account Name:" + account.AccountName + "\n sahre number" + account.ShareNumber + "\n stock price " + account.Shareprice);
                sum += account.Shareprice;
            }
            Console.WriteLine("Total value of accounts store in database Rs." + sum);
        }
        /// <summary>
        /// Displays the account.
        /// </summary>
        public void DisplayAccount()
        {
            string accountname;
            while (true)
            {
                Console.WriteLine("Enter the account name for which you want to buy");
                accountname = Console.ReadLine();
                if (Utility.ContainsCharacter(accountname))
                {
                    Console.WriteLine("no character allowed");
                    continue;
                }
                if (Utility.ConatainsDigit(accountname))
                {
                    Console.WriteLine("no digit allowed");
                    continue;
                }
                if (Utility.CheckString(accountname))
                {
                    Console.WriteLine("you should specify name");
                    continue;
                }

                NewAccount newAccount = JsonRead.JsonReadFile();
                List<AccountModel> accounts = newAccount.AccountList;
                foreach (AccountModel name in accounts)
                {
                    if (name.AccountName.Equals(accountname))
                    {
                        Console.WriteLine("Account Name:" + name.AccountName + "\n sahre number" + name.ShareNumber + "\n stock price " + name.Shareprice);
                    }
                }
                break;

            }
        }
        /// <summary>
        /// Buys this instance.
        /// </summary>
        public void Buy()
        {
            string accountname;
            while (true)
            {
                Console.WriteLine("Enter the account name for which you want to buy");
                accountname = Console.ReadLine();
                if (Utility.ContainsCharacter(accountname))
                {
                    Console.WriteLine("no character allowed");
                    continue;
                }
                if (Utility.ConatainsDigit(accountname))
                {
                    Console.WriteLine("no digit allowed");
                    continue;
                }
                if (Utility.CheckString(accountname))
                {
                    Console.WriteLine("you should specify name");
                    continue;
                }
                /////Updating the share number and price
                NewAccount newAccount = JsonRead.JsonReadFile();
                List<AccountModel> accounts = newAccount.AccountList;
                foreach (AccountModel name in accounts)
                {
                    if (name.AccountName.Equals(accountname))
                    {
                        Console.WriteLine("Enter share price buy");
                        double price = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Enter share Number You want to Buy");
                        int Number = Convert.ToInt32(Console.ReadLine());
                        name.ShareNumber = name.ShareNumber + Number;
                        name.Shareprice = name.Shareprice + price;
                    }
                   
                }
                FileWrite.WriteInToFile(newAccount);
                Console.WriteLine(accountname + "had Successfully buy their share stock price");
                break;
            }

        }
        /// <summary>
        /// Sells this instance.
        /// </summary>
        public void Sell()
        {
            string accountname;
            while (true)
            {
                Console.WriteLine("Enter the account name for which you want to Sell");
                accountname = Console.ReadLine();
                if (Utility.ContainsCharacter(accountname))
                {
                    Console.WriteLine("no character allowed");
                    continue;
                }
                if (Utility.ConatainsDigit(accountname))
                {
                    Console.WriteLine("no digit allowed");
                    continue;
                }
                if (Utility.CheckString(accountname))
                {
                    Console.WriteLine("you should specify name");
                    continue;
                }
                ////Updating the share number and price after sell
                NewAccount newAccount = JsonRead.JsonReadFile();
                List<AccountModel> accounts = newAccount.AccountList;
                foreach (AccountModel name in accounts)
                {
                    if (name.AccountName.Equals(accountname)) 
                    {
                        Console.WriteLine("Enter share number you want to buy");
                        double price = Convert.ToDouble(Console.ReadLine());
                        int Number = Convert.ToInt32(Console.ReadLine());
                        name.ShareNumber = name.ShareNumber - Number;
                        name.Shareprice = name.Shareprice - price;
                    }
                    
                }
                FileWrite.WriteInToFile(newAccount);
                Console.WriteLine(accountname + "had Successfully sell their share stock price");
                break;
            }
        }
    }
}