// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Newlist.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace OOPS.StockReport
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    /// <summary>
    /// Newlist is class which has the property of list genric type and the genric type is StockModel
    /// </summary>
    class Newlist
    {
        private List<StockModel> accountList = new List<StockModel>();
        public List<StockModel> AccountList { get; set; }
    }
}