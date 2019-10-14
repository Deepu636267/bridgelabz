// --------------------------------------------------------------------------------------------------------------------
// <copyright file=NewAddress.cs" company="Bridgelabz">
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
    /// NewAddress is class which has the property of list genroc type and the genric type is BookModel
    /// </summary>
    class NewAddress
    {
        private List<BookModel> accountList = new List<BookModel>();
        public List<BookModel> AddressList { get; set; }
    }
}
