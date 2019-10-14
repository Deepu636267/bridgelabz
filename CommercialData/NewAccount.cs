// --------------------------------------------------------------------------------------------------------------------
// <copyright file=NewAccount.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace OOPS.CommercialData
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    /// <summary>
    /// NewAccount is class which has the property of list genric type and the genric type is AccountModel
    /// </summary>
    class NewAccount
    {
        private List<AccountModel> accountList = new List<AccountModel>();
        public List<AccountModel> AccountList { get; set; }
    }
}