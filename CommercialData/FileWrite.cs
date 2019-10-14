// --------------------------------------------------------------------------------------------------------------------
// <copyright file=FileWrite.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace OOPS.CommercialData
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    /// <summary>
    /// FileWrite is class which is write the data in to the json file.
    /// </summary>
    class FileWrite
    {
        /// <summary>
        /// Writes the in to file.
        /// </summary>
        /// <param name="newAccount">The new account.</param>
        public static void WriteInToFile(NewAccount newAccount)
        {
            string path = (@"C:\Users\Bridgelabz\source\repos\OOPS\CommercialData\CommercialList.json");
            ////Serialize the object into json Compatible
            var writeData = JsonConvert.SerializeObject(newAccount);
            StreamWriter stream = new StreamWriter(path);
            stream.Write(writeData);
            stream.Close();
        }
    }
}