// --------------------------------------------------------------------------------------------------------------------
// <copyright file=InventoryFactory.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace OOPS.InventoryMangementData
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    /// <summary>
    ///  InventoryModel is class which represent the how the dat will be read or write from json in which format.
    /// </summary>
    class InventoryFactory
    {
        private string name;
        private double weight;
        private double priceperkg;
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Priceperkg { get; set; }
        /// <summary>
        /// Jsons the read file.
        /// </summary>
        /// <returns></returns>
        public static NewAccount JsonReadFile()
        {
            string path = @"C:\Users\Bridgelabz\source\repos\OOPS\InventoryMangementData\js1.json";
            StreamReader read = new StreamReader(path);
            string json = read.ReadToEnd();
            //// Convert json format to string format.
            NewAccount account = JsonConvert.DeserializeObject<NewAccount>(json);
            read.Close();
            return account;
        }
        /// <summary>
        /// Totals the specified w.
        /// </summary>
        /// <param name="w">The w.</param>
        /// <param name="p">The p.</param>
        /// <returns></returns>
        public double Total(double w,double p)
        {
            return (w * p);          
        }
    }
}
