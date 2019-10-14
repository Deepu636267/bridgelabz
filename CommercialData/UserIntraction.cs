// --------------------------------------------------------------------------------------------------------------------
// <copyright file=UserIntraction.cs" company="Bridgelabz">
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
    /// UserIntraction is class which can be used for how the user will interact our program
    /// </summary>
    class UserIntraction
    {
        /// <summary>
        /// Users the choice.
        /// </summary>
        public void UserChoice()
        {
            try
            {
                 int UserChoice = 0;
                 Console.WriteLine("What do you want to perform");
                 Console.WriteLine("");
                 Console.WriteLine("1.Create new Account");
                 Console.WriteLine("2.Display total value of Account stock");
                 Console.WriteLine("3.Add share and stock to Account");
                 Console.WriteLine("4.Buy Share of stock from account");
                 Console.WriteLine("5.Sell Shares of stock fronm Account");
                 Console.WriteLine("Display particular Account details reports of shares and stocks");
                 Console.WriteLine("Enter your choice to perform");
                 UserChoice = Convert.ToInt32(Console.ReadLine());
                 Console.WriteLine("");
                 switch (UserChoice)
                 {
                       case 1:
                             CreateAccount newly = new CreateAccount();
                             newly.Create();
                            break;
                       case 2:
                            AccountOperation account = new AccountOperation();
                            account.DisplayStock();
                            break;
                       case 3:
                            AccountOperation accountbuy = new AccountOperation();
                            accountbuy.Buy();
                            break;
                       case 4:
                            AccountOperation displayaccount = new AccountOperation();
                            displayaccount.DisplayAccount();
                            break;
                       case 5:
                            AccountOperation accountsell = new AccountOperation();
                            accountsell.Sell();
                            break;
                 }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}