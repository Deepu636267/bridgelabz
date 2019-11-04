using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Common.Models.UserModels
{
    public class ForgetPasswordModel
    {
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
