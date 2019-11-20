using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models.AdminModels
{
    public class AdminUserDetailsModel
    {
        private int sNo;
        private string userName;
        private DateTime? Login_Date_Time;
        private string service;
        public int SNo
        {
            get
            {
                return this.sNo;
            }
            set
            {
                this.sNo = value;
            }
        }
    }
}
