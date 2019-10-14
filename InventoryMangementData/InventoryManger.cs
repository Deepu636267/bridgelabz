// --------------------------------------------------------------------------------------------------------------------
// <copyright file=InventoryManger.cs" company="Bridgelabz">
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
    /// InventoryManger is the class  for operation
    /// </summary>
    class InventoryManger
    {
        /// <summary>
        /// Mangers this instance.
        /// </summary>
        public void Manger()
        {
            InventoryFactory inventory = new InventoryFactory();
            NewAccount newAccount = InventoryFactory.JsonReadFile();
            List<InventoryFactory> accountModels = newAccount.AccountList;
            double sum = 0;
            foreach (var account in accountModels)
            {
                Console.WriteLine("");
                Console.WriteLine("Name:" + account.Name + "\nWeight" + account.Weight + "\nPrice " + account.Priceperkg);
                sum += inventory.Total(account.Weight,account.Priceperkg);
                Console.WriteLine("total Price for this item :" + sum);
            }
            Console.WriteLine("total Price Is :" + sum);
        }
    }
}