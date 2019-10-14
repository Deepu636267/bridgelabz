// --------------------------------------------------------------------------------------------------------------------
// <copyright file=CreateAccount.cs" company="Bridgelabz">
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
    /// CreateAccount is class for creating new Account
    /// </summary>
    class CreateAccount
    {
        /// <summary>
        /// Creates this instance.
        /// </summary>
        public void Create()
        {
            string accountname = null;
            int sharenumber = 0;
            double shareprice = 0;
            Console.WriteLine("Enter Name to create an account");
            accountname = Console.ReadLine();
            while (true)
            {
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
                break;
            }
            ////sending data to the model class by creating object and store it like json file
            AccountModel.CreateAccountObject(accountname, sharenumber, shareprice);
            Console.WriteLine("New Account has been created with name " + accountname);
        }
    }
}