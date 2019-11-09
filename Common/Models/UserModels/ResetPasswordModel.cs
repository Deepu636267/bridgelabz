// --------------------------------------------------------------------------------------------------------------------
// <copyright file=ResetPasswordModel.cs" company="Bridgelabz">
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
    /// ResetPasswordModel is a basic structure
    /// </summary>
    public class ResetPasswordModel
    {
        private string email;
        private string oldPassword;
        private string newPassword;
        private string confirmPassword;
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [ForeignKey("UserModels")]
        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                this.email = value;
            }
        }
        /// <summary>
        /// Gets or sets the old password.
        /// </summary>
        /// <value>
        /// The old password.
        /// </value>
        public string OldPassword
        {
            get
            {
                return this.oldPassword;
            }
            set
            {
                this.oldPassword = value;
            }
        }
        /// <summary>
        /// Creates new password.
        /// </summary>
        /// <value>
        /// The new password.
        /// </value>
        public string NewPassword
        {
            get
            {
                return this.newPassword;
            }
            set
            {
                this.newPassword = value;
            }
        }
        /// <summary>
        /// Gets or sets the confirm password.
        /// </summary>
        /// <value>
        /// The confirm password.
        /// </value>
        public string ConfirmPassword
        {
            get
            {
                return this.confirmPassword;
            }
            set
            {
                this.confirmPassword = value;
            }
        }
    }
}