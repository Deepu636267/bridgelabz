// --------------------------------------------------------------------------------------------------------------------
// <copyright file=AccountModel.cs" company="Bridgelabz">
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
    ///  AccountModel is class which represent the how the dat will be read or write from json in which format.
    /// </summary>
    class AccountModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountModel"/> class.
        /// </summary>
        /// <param name="accountname">The accountname.</param>
        /// <param name="sharenumber">The sharenumber.</param>
        /// <param name="shareprice">The shareprice.</param>
        public AccountModel(string accountname, int sharenumber, double shareprice)
        {
            AccountName = accountname;
            ShareNumber = sharenumber;
            Shareprice = shareprice;
        }

        public string AccountName { get; set; }
        public int ShareNumber { get; set; }
        public double Shareprice { get; set; }
        /// <summary>
        /// Creates the account object.
        /// </summary>
        /// <param name="accountname">The accountname.</param>
        /// <param name="sharenumber">The sharenumber.</param>
        /// <param name="shareprice">The shareprice.</param>
        public static void CreateAccountObject(string accountname, int sharenumber, double shareprice)
        {
            AccountModel account = new AccountModel(accountname, sharenumber, shareprice);
            NewAccount newAccount = JsonRead.JsonReadFile();
            newAccount.AccountList.Add(account);
            FileWrite.WriteInToFile(newAccount);
            Console.WriteLine("Account had been successfully created");
        }
    }
}