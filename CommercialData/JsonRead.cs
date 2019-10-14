// --------------------------------------------------------------------------------------------------------------------
// <copyright file=JsonRead.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace OOPS.CommercialData
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    /// <summary>
    /// JsonRead is class for read the data from json file 
    /// </summary>
    class JsonRead
    {
        /// <summary>
        /// Jsons the read file.
        /// </summary>
        /// <returns></returns>
        public static NewAccount JsonReadFile()
        {
            string path = (@"C:\Users\Bridgelabz\source\repos\OOPS\CommercialData\CommercialList.json");
            StreamReader read = new StreamReader(path);
            string json = read.ReadToEnd();
            //// Convert json format to string format.
            NewAccount account = JsonConvert.DeserializeObject<NewAccount>(json);
            read.Close();
            return account;
        }
    }
}