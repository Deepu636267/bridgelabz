using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models.AdminModels
{
    public class AdminUserStatisticModel
    {
        private int sNo;
        private string userEmail;
        private DateTime login_Date_Time;
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
        public string UserEmail
        {
            get
            {
                return this.userEmail;
            }
            set
            {
                this.userEmail = value;
            }
        }
        public DateTime Login_Date_Time
        {
            get
            {
                return this.login_Date_Time;
            }
            set
            {
                this.login_Date_Time = value;
            }
        }

        public string Service
        {
            get
            {
                return this.service;
            }
            set
            {
                this.service = value;
            }
        }
    }
}