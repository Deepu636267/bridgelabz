// --------------------------------------------------------------------------------------------------------------------
// <copyright file=InventoryData.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace OOPS.InventoryManageMent
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    using Newtonsoft.Json;
    /// <summary>
    /// InventoryData  is class 
    /// </summary>
    class InventoryData
    {
        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void display()
        {
            try
            {
                ////Read the File Path
                string path = (@"C:\Users\Bridgelabz\source\repos\OOPS\InventoryManageMent\js1.json");
                StreamReader read = new StreamReader(path);
                ////Read all From Starting to ending
                var json = read.ReadToEnd();
                /////Deserialize the json data
                var items = JsonConvert.DeserializeObject<List<InventoryModel>>(json);
                Console.WriteLine("Name"+"\tWeight(kg)"+"\tPrice(Rs.)"+"\tTotalPrice(Rs.)");
                foreach(var item in items)
                {
                    Console.WriteLine(item.Name +"\t"+item.Weight +"\t\t" +item.PricePerKg + "\t\t" +(item.Weight * item.PricePerKg));
                }
                ////Display the total cost of the items.
                InventoryModel model = new InventoryModel();
                model.total();
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}