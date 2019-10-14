// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Read.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace OOPS.StockReport
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    /// <summary>
    /// Read is class for read the data from json file 
    /// </summary>
    class Read
    {
        public static Newlist JsonReadFile()
        {
            string path = (@"C:\Users\Bridgelabz\source\repos\OOPS\StockReport\StockData.json");
            StreamReader read = new StreamReader(path);
            string json = read.ReadToEnd();
            //// Convert json format to string format.
            Newlist account = JsonConvert.DeserializeObject<Newlist>(json);
            read.Close();
            return account;
        }
    }
}