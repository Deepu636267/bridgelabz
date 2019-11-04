using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Common.Models.UserModels
{
    public class LoginModel
    {
        private string email;
        private string password;
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
