// --------------------------------------------------------------------------------------------------------------------
// <copyright file=InventoryModel.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace OOPS.InventoryManageMent
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    /// <summary>
    ///  InventoryModel is class which represent the how the dat will be read or write from json in which format.
    /// </summary>
    class InventoryModel
    {
        private string _name;
        private double _weight;
        private double _priceperkg;
        //public InventoryModel(string name, double weight, double priceperkg)
        //{
        //    _name = name;
        //    _weight = weight;
        //    _priceperkg = priceperkg;
        //}
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public double Weight
        {
            get => _weight;
            set => _weight = value;
        }
        public double PricePerKg
        {
            get => _priceperkg;
            set => _priceperkg=value;
        }
        public  void total()
        {
           double val= Weight * PricePerKg;
            Console.WriteLine(val);
        }
        /* public string getname()
         {
             return name;
         }
         public void setname(string name)
         {
             this.name = name;
         }
         public double getweight()
         {
             return weight;
         }
         public void setweight(double weight)
         {
             this.weight = weight;
         }
         public double getpriceperkg()
         {
             return priceperkg;
         }
         public void setpriceperkg(double priceperkg)
         {
             this.priceperkg = priceperkg;
         }*/
      /*  public string Name { get; set; }
        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        /// <value>
        /// The weight.
        /// </value>
        public double Weight { get; set; }
        /// <summary>
        /// Gets or sets the price per kg.
        /// </summary>
        /// <value>
        /// The price per kg.
        /// </value>
        public double PricePerKg { get; set; }*/
    }
}