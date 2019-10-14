// --------------------------------------------------------------------------------------------------------------------
// <copyright file=FileWrite.cs" company="Bridgelabz">
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
    /// FileWrite is class which is write the data in to the json file.
    /// </summary>
    class FileWrite
    {
        /// <summary>
        /// Writes the data in to file.
        /// </summary>
        /// <param name="newAccount">The new account. for list type</param>
        public static void WriteInToFile(NewAddress newAccount)
        {
            string path = (@"C:\Users\Bridgelabz\source\repos\OOPS\AddressBookModel\AddressBook.json");
            var writeData = JsonConvert.SerializeObject(newAccount);
            StreamWriter stream = new StreamWriter(path);
            stream.Write(writeData);
            stream.Close();
        }
    }
}