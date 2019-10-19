// --------------------------------------------------------------------------------------------------------------------
// <copyright file=SocketAdapter.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace DesignPattern.StructuralDesignPattern.AdapterDesign
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    /// <summary> 
    /// SocketAdapter is interface which have methods get120Volt() and get12Volt()
    /// </summary>
    public interface SocketAdapter
    {
        public Volt get120Volt();
        public Volt get12Volt();
        public Volt get3Volt();
    }
}