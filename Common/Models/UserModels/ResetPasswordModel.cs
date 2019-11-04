using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Common.Models.UserModels
{
    public class ResetPasswordModel
    {
        private string email;
        private string oldPassword;
        private string newPassword;
        private string confirmPassword;
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