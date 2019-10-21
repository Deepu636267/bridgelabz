// --------------------------------------------------------------------------------------------------------------------
// <copyright file=IInvestor.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace DesignPattern.ObserverDesignPattern
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    /// <summary>
    /// IInvestor is an interface
    /// </summary>
    public interface IInvestor
    {
        void Update(Stock stock);
    }
}