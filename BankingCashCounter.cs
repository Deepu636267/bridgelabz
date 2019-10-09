// --------------------------------------------------------------------------------------------------------------------
// <copyright file=BankingCashCounter.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace DataStructure
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    /// <summary>
    /// BankingCashCounter is a class for mainting the banking system
    /// </summary>
    class BankingCashCounter
    {
        Utility util = new Utility();
        QueueLInkedList<int> List = new QueueLInkedList<int>();
        internal static int InitialAmount = 50000;
        internal static int DepositeAmount =0;
        internal static int WithdrawAmount =0;
        public void CashCounter()
        {
            BankingCashCounter bankdata = new BankingCashCounter();
            ////Enter the people in queue to operate sequential
            Console.WriteLine("Enter the total number of People in line");
            int Number = util.InputInteger();
            for(int i=1;i<=Number;i++)
            {
                List.EnQueue(i);
            }
            /////for people come and choose its on requirement
            for(int i=1;i<=Number;i++)
            {
                List.DequeueBank();
                Console.WriteLine("Welcome in the Bank");
                Console.WriteLine("What Type of Service you want...");
                Console.WriteLine("Press 1 for Depositing Amount" + "\n Press 2 For Withdraw Amount");
                int customerInput = util.InputInteger();
                switch(customerInput)
                {
                    case 1:
                        int Data;
                        do
                        {
                            Data = util.DepositeCash(bankdata);
                        } while (Data == -1);
                        Console.WriteLine("Your available Balance after Deposite = Rs." + InitialAmount);
                        break;
                    case 2:
                        int Data1;
                        do
                        {
                            Data1=util.WithDrawalCash(bankdata);
                        } while (Data1 == -1);
                        Console.WriteLine("Your available Balance after withdrawal = Rs." + InitialAmount);
                        break;
                }
            }
            ////printing the total deposie amount and tota withdraw amount and total available balance.
            Console.WriteLine("\nClosed For Services:");
            Console.WriteLine("\nToday Total Deposite Amount :"+DepositeAmount);
            Console.WriteLine("\nToday Total Withdraw Amount :" +WithdrawAmount);
            Console.WriteLine("Cash Balance In Bank is:");
            int AfterDeposite = 50000 +DepositeAmount;
            Console.WriteLine("After total Withdraw Amount:" + AfterDeposite);
            int AfterWithdraw = AfterDeposite - WithdrawAmount;
            Console.WriteLine("After all Transction will be done the Total avaialable amount in bank is:" + AfterDeposite);
        }
    }
}