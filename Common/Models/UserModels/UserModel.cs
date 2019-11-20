// --------------------------------------------------------------------------------------------------------------------
// <copyright file=UserModel.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace Common.Models.UserModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;
    /// <summary>
    /// UserModel is a class for basic stucture
    /// </summary>
    public class UserModel
    {
        private int iD;
        private string firstName;
        private string lastName;
        private string email;
        private string password;
        private string cardType;
        private string profilePic;
        private int totalNotes;
        private string status;

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>z
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID
        {
            get
            {
                return this.iD;
            }
            set
            {
                this.iD = value;
            }
        }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        [Required]
        public string  FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                this.firstName = value;

            }
        }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        [Required]
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value;

            }
        }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [Key]
        [Required]
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
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [Required]
        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;

            }
        }

        /// <summary>
        /// Gets or sets the type of the card.
        /// </summary>
        /// <value>
        /// The type of the card.
        /// </value>
        public string CardType
        {
            get
            {
                return this.cardType;
            }
            set
            {
                this.cardType = value;
            }
        }

        /// <summary>
        /// Gets or sets the profile pic.
        /// </summary>
        /// <value>
        /// The profile pic.
        /// </value>
        public string ProfilePic
        {
            get
            {
                return this.profilePic;
            }
            set
            {
                this.profilePic = value;
            }
        }

        /// <summary>
        /// Gets or sets the total notes.
        /// </summary>
        /// <value>
        /// The total notes.
        /// </value>
        public int TotalNotes
        {
            get
            {
                return this.totalNotes;
            }
            set
            {
                this.totalNotes = value;
            }
        }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public string Status
        {
            get
            {
                return this.status;
            }
            set
            {
                this.status = value;
            }
        }
    }
}