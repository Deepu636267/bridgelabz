// --------------------------------------------------------------------------------------------------------------------
// <copyright file=HouseTemplate.cs" company="Bridgelabz">
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
    /// HouseTemplate is abstrcat type class where all main method will be declared
    /// </summary>
    public abstract class HouseTemplate
    {
        //template method, final so subclasses can't override
        public  void BuildHouse()
        {
            BuildFoundation();
            BuildPillars();
            BuildWalls();
            BuildWindows();
            Console.WriteLine("House is built.");
        }
        //default implementation
        private void BuildWindows()
        {
            Console.WriteLine("Building Glass Windows");
        }
        //methods to be implemented by subclasses
        public abstract void BuildWalls();
        public abstract void BuildPillars();
        private void BuildFoundation()
        {
            Console.WriteLine("Building foundation with cement,iron rods and sand");
        }
    }
}