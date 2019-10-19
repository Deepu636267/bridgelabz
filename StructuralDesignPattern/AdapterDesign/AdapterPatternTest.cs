// --------------------------------------------------------------------------------------------------------------------
// <copyright file=AdapterPatternTest.cs" company="Bridgelabz">
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
    /// AdapterPatternTest is class where we test the our object creation
    /// </summary>
    public class AdapterPatternTest
    {
        /// <summary>
        /// Tests the object adapter.
        /// </summary>
        public void testObjectAdapter()
        {
            SocketAdapter sockAdapter = new SocketObjectAdapterImpl();
            Volt v3 = getVolt(sockAdapter, 3);
            Volt v12 = getVolt(sockAdapter, 12);
            Volt v120 = getVolt(sockAdapter, 120);
            Console.WriteLine("v3 volts using Object Adapter=" + v3.getVolts());
            Console.WriteLine("v12 volts using Object Adapter=" + v12.getVolts());
            Console.WriteLine("v120 volts using Object Adapter=" + v120.getVolts());
        }
        /// <summary>
        /// Tests the class adapter.
        /// </summary>
        public void testClassAdapter()
        {
            SocketAdapter sockAdapter = new SocketClassAdapterImpl();
            Volt v3 = getVolt(sockAdapter, 3);
            Volt v12 = getVolt(sockAdapter, 12);
            Volt v120 = getVolt(sockAdapter, 120);
            Console.WriteLine("v3 volts using Class Adapter=" + v3.getVolts());
            Console.WriteLine("v12 volts using Class Adapter=" + v12.getVolts());
            Console.WriteLine("v120 volts using Class Adapter=" + v120.getVolts());
        }
        /// <summary>
        /// Gets the volt.
        /// </summary>
        /// <param name="sockAdapter">The sock adapter.</param>
        /// <param name="i">The i.</param>
        /// <returns></returns>
        private Volt getVolt(SocketAdapter sockAdapter, int i)
        {
            ////using switch(i) is for which type of object will create and returnthats type
            switch (i)
            {
                case 3: return sockAdapter.get3Volt();
                case 12: return sockAdapter.get12Volt();
                case 120: return sockAdapter.get120Volt();
                default: return sockAdapter.get120Volt();
            }
        }
    }
}