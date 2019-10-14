// --------------------------------------------------------------------------------------------------------------------
// <copyright file=BookModel.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace OOPS.AddressBookModel
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    /// <summary>
    /// BookModel is class which represent the how the dat will be read or write from json in which format.
    /// </summary>
    class BookModel
    {
        private string Firstname;
        private string Lastname;
        private long phonenumber;
        private string city;
        private string state;
        private long zip;
        /// <summary>
        /// Initializes a new instance of the <see cref="BookModel"/> class.
        /// </summary>
        /// <param name="firstname">The firstname.</param>
        /// <param name="lastname">The lastname.</param>
        /// <param name="phonenumber">The phonenumber.</param>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <param name="zip">The zip.</param>
        public BookModel(string firstname, string lastname,long phonenumber, string city, string state, long zip)
        {
            FirstName = firstname;
            Lastname = lastname;
            PhoneNumber = phonenumber;
            City = city;
            State = state;
            Zip = zip;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PhoneNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public long Zip { get; set; }
        /// <summary>
        /// Creates the account object.
        /// </summary>
        /// <param name="firstname">The firstname.</param>
        /// <param name="lastname">The lastname.</param>
        /// <param name="phonenumber">The phonenumber.</param>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <param name="zip">The zip.</param>
        public static void CreateAccountObject(string firstname,string lastname, long phonenumber, string city, string state, long zip)
        {
            BookModel account = new BookModel(firstname, lastname,phonenumber, city,state,zip);
            NewAddress newAccount = JsonRead.JsonReadFile();
            newAccount.AddressList.Add(account);
            FileWrite.WriteInToFile(newAccount);
            Console.WriteLine("Account had been successfully created");
        }
    }
}