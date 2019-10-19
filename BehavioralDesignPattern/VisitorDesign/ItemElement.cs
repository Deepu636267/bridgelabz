// --------------------------------------------------------------------------------------------------------------------
// <copyright file=ItemElement.cs" company="Bridgelabz">
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
    /// ItemElement is an Interface
    /// </summary>
    public interface ItemElement
    {
        public int Accept(ShoppingCartVisitor visitor);
    }
}