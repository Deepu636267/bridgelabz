// --------------------------------------------------------------------------------------------------------------------
// <copyright file=StockModel.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace OOPS.StockReport
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    /// <summary>
    ///  AccountModel is class which represent the how the dat will be read or write from json in which format.
    /// </summary>
    class StockModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StockModel"/> class.
        /// </summary>
        /// <param name="stockname">The stockname.</param>
        /// <param name="stockperson">The stockperson.</param>
        /// <param name="stockprice">The stockprice.</param>
        public StockModel(string stockname,int stockperson,double stockprice)
        {
           Stockname = stockname;
            Shareperson = stockperson;
            Stockprice = stockprice;
        }
        public string Stockname { get; set; }
        public int Shareperson { get; set; }
        public double Stockprice { get; set; }
        /// <summary>
        /// Creats the object model.
        /// </summary>
        /// <param name="stockname">The stockname.</param>
        /// <param name="shareperson">The shareperson.</param>
        /// <param name="stockprice">The stockprice.</param>
        public static void CreatObjectModel(string stockname,int shareperson,double stockprice)
        {
            StockModel stock = new StockModel(stockname,shareperson,stockprice);
           Newlist newAccount = Read.JsonReadFile();
            newAccount.AccountList.Add(stock);
            FileWrite.WriteInToFile(newAccount);
        }
    }
}