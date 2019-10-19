// --------------------------------------------------------------------------------------------------------------------
// <copyright file=WoodenHouse.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace DesignPattern.BehavioralDesignPattern.TemplateDesign
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    /// <summary>
    /// WoodenHouse is class which inherit the Wooden House abstract class 
    /// </summary>
    /// <seealso cref="DesignPattern.BehavioralDesignPattern.TemplateDesign.HouseTemplate" />
    public class WoodenHouse : HouseTemplate
    {
        /// <summary>
        /// Builds the walls.
        /// </summary>
        public override void BuildWalls()
        {
            Console.WriteLine("Building Wooden Walls");
        }

        /// <summary>
        /// Builds the pillars.
        /// </summary>
        public override void BuildPillars()
        {
            Console.WriteLine("Building Pillars with Wood coating");
        }
    }
}