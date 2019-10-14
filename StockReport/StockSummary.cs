// --------------------------------------------------------------------------------------------------------------------
// <copyright file=StockSummary.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace OOPS.StockReport
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    using Newtonsoft.Json;
    /// <summary>
    /// Display is a inteface
    /// </summary>
    interface Display
    {
        void DisplayStock();
    }
    /// <summary>
    /// StockSummary is class which has inherit the property of Display intrface
    /// </summary>
    /// <seealso cref="OOPS.StockReport.Display" />
    class StockSummary :Display
    {
        /// <summary>
        /// Summaries this instance taking data from user and send to the StockModel to store tthe data
        /// </summary>
        public void Summary()
        {
            try
            {
                double totalstockcost = 0;
                //string path = (@"C:\Users\Bridgelabz\source\repos\OOPS\StockReport\StockData.json");
                //StreamReader read = new StreamReader(path);
                ////// Read all the character from current position to the end of the stream.
                //var json = read.ReadToEnd();
                //// Convert json format to string format.
                //StockModel[] items = JsonConvert.DeserializeObject<StockModel[]>(json);
                //Console.WriteLine("");
                //Console.WriteLine("Stock details for vechicles");
                //Console.WriteLine("");
                //for (int i = 0; i < items.Length; i++)
                //{
                //    Console.WriteLine("Stock Name:- " + items[i].Stockname);
                //    Console.WriteLine("Share Person:-" + items[i].Shareperson);
                //    Console.WriteLine("Each Stock Cost:- Rs." + items[i].Stockprice);
                //    Console.WriteLine("Total cost for" + items[i].Stockname + ":-Rs." + (items[i].Shareperson * items[i].Stockprice));
                //    Console.WriteLine(" ");
                //    totalstockcost = totalstockcost + (items[i].Stockprice * items[i].Shareperson);
                //}
                Console.WriteLine("How Many Inputs You have want to enter");
                int N = Convert.ToInt32(Console.ReadLine());
                for(int i=0;i<N;i++)
                {
                    Console.WriteLine("Enter the Stock Name:");
                    string StockName = Console.ReadLine();
                    Console.WriteLine("Enter the Number of Share");
                    int ShareNumber = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the Stock Price");
                    double StockCost = Convert.ToInt32(Console.ReadLine());
                    totalstockcost = totalstockcost+(ShareNumber * StockCost);
                    StockModel.CreatObjectModel(StockName, ShareNumber, StockCost);
                }
                Console.WriteLine("Total  Added Cost for all Stock = Rs." + totalstockcost);
                DisplayStock();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Displays the stock.
        /// </summary>
        public void DisplayStock()
        {
            Newlist newAccount = Read.JsonReadFile();
            List<StockModel> accountModels = newAccount.AccountList;
            double sum = 0;
            foreach (var account in accountModels)
            {
                Console.WriteLine("");
                Console.WriteLine("Stock Name:" + account.Stockname + "\n sahre number" + account.Shareperson + "\n stock price " + account.Stockprice);
                sum += account.Stockprice*account.Shareperson;
            }
            Console.WriteLine("Total value of accounts store in database Rs." + sum);
        }
    }
}