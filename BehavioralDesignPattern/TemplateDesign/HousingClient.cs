// --------------------------------------------------------------------------------------------------------------------
// <copyright file=HousingClient.cs" company="Bridgelabz">
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
    /// HousingClient is class for taking care of hich type of house will be made
    /// </summary>
    public class HousingClient
    {
        public  void ClientMain()
        {
           HouseTemplate houseType = new WoodenHouse();
           //using template method
           houseType.BuildHouse();
           Console.WriteLine("************");
           houseType = new GlassHouse();
           houseType.BuildHouse();
        }
    }
}