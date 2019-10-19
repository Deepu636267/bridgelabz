// --------------------------------------------------------------------------------------------------------------------
// <copyright file=ShoppingCartVisitor.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace DesignPattern.BehavioralDesignPattern.VisitorDesign
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    /// <summary>
    /// ShoppingCartVisitor is an inteface 
    /// </summary>
    public interface ShoppingCartVisitor
    {
        int Visit(Book book);
        int Visit(Fruit fruit);
    }
}