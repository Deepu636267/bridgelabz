// --------------------------------------------------------------------------------------------------------------------
// <copyright file=GlassHouse.cs" company="Bridgelabz">
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
    /// GlassHouse is a clas which inherit the HouseTemplate abstarct class to define the procedure of making house
    /// </summary>
    /// <seealso cref="DesignPattern.BehavioralDesignPattern.TemplateDesign.HouseTemplate" />
    public class GlassHouse :HouseTemplate
    {
        /// <summary>
        /// Builds the walls.
        /// </summary>
        public override void BuildWalls()
        {
            Console.WriteLine("Building Glass Walls");
        }
        /// <summary>
        /// Builds the pillars.
        /// </summary>
        public override void BuildPillars()
        {
            Console.WriteLine("Building Pillars with glass coating");
        }
    }
}