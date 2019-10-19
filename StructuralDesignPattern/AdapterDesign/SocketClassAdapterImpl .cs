// --------------------------------------------------------------------------------------------------------------------
// <copyright file=SocketClassAdapterImpl.cs" company="Bridgelabz">
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
    /// SocketClassAdapterImpl is class which has multiple inheritance
    /// </summary>
    //Using inheritance for adapter pattern
    public class SocketClassAdapterImpl : Socket,SocketAdapter
    {
        /// <summary>
        /// Get120s the volt.
        /// </summary>
        /// <returns></returns>
       public Volt get120Volt()
       {
          return getVolt();
       }
        /// <summary>
        /// Get12s the volt.
        /// </summary>
        /// <returns></returns>
       public Volt get12Volt()
       {
          Volt v = getVolt();
          return convertVolt(v, 10);
       }
        /// <summary>
        /// Get3s the volt.
        /// </summary>
        /// <returns></returns>
       public Volt get3Volt()
       {
          Volt v = getVolt();
          return convertVolt(v, 40);
       }
        /// <summary>
        /// Converts the volt.
        /// </summary>
        /// <param name="v">The v.</param>
        /// <param name="i">The i.</param>
        /// <returns></returns>
       private Volt convertVolt(Volt v, int i)
       {
          return new Volt(v.getVolts() / i);
       }
    }
}