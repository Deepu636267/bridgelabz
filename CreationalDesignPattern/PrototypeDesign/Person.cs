// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Prototype.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace DesignPattern.CreationalDesignPattern.PrototypeDesign
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    /// <summary>
    /// Person is a class
    /// </summary>
    public class Person
    {
        public int Age;
        public DateTime BirthDate;
        public string Name;
        public IdInfo IdInfo;
        /// <summary>
        /// Shallows the copy.
        /// </summary>
        /// <returns></returns>
        public Person ShallowCopy()
        {
            return (Person)this.MemberwiseClone();
        }
        /// <summary>
        /// Deeps the copy.
        /// </summary>
        /// <returns></returns>
        public Person DeepCopy()
        {
            Person clone = (Person)this.MemberwiseClone();
            clone.IdInfo = new IdInfo(IdInfo.IdNumber);
            clone.Name = string.Copy(Name);
            return clone;
        }
    }
    /// <summary>
    /// IdInfo is a class
    /// </summary>
    public class IdInfo
    {
        public int IdNumber;
        /// <summary>
        /// Initializes a new instance of the <see cref="IdInfo"/> class.
        /// </summary>
        /// <param name="idNumber">The identifier number.</param>
        public IdInfo(int idNumber)
        {
            this.IdNumber = idNumber;
        }
    }
}