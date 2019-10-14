// --------------------------------------------------------------------------------------------------------------------
// <copyright file=JsonRead.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace OOPS.AddressBookModel
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    /// <summary>
    /// JsonRead is class for raed the data from json file 
    /// </summary>
    class JsonRead
    {
        /// <summary>
        /// Jsons the read file.
        /// </summary>
        /// <returns> with NewAddress type because it hold the property of list collection used</returns>
        public static NewAddress JsonReadFile()
        {
            string path = (@"C:\Users\Bridgelabz\source\repos\OOPS\AddressBookModel\AddressBook.json");
            StreamReader read = new StreamReader(path);
            string json = read.ReadToEnd();
            //// Convert json format to string format.
            NewAddress account = JsonConvert.DeserializeObject<NewAddress>(json);
            read.Close();
            return account;
        }
    }
}
