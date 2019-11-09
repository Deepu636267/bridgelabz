// --------------------------------------------------------------------------------------------------------------------
// <copyright file=ForgetPasswordModel.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace Common.Models.UserModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;
    /// <summary>
    /// ForgetPasswordModel is a class for basic structure
    /// </summary>
    public class ForgetPasswordModel
    {
        /// <summary>
        /// The email
        /// </summary>
        private string email;
        [ForeignKey("USerModel")]
        public string Email
        {
            get
            {
               return this.email ;
            }
            set
            {
                this.email=value;
            }
        }
    }
}
