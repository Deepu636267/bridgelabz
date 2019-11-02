using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Models.UserModels
{
    public class UserModel
    {
        private string firstName;
        private string lastName;
        private string email;
        private string password;
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
    }
}
