using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models.NotesModels
{
    public class NotificationModel
    {
        private string email;
        private string deviceId;
        private string message;
        private string tagmessage;
        private string reminder;
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
        public string DeviceId
        {
            get
            {
                return this.deviceId;
            }
            set
            {
                this.deviceId = value;
            }
        }
        public string Message
        {
            get
            {
                return this.message;
            }
            set
            {
                this.message = value;
            }
        }
        public string Tagmessage
        {
            get
            {
                return this.tagmessage;
            }
            set
            {
                this.tagmessage = value;
            }
        }
        public string Reminder
        {
            get
            {
                return this.reminder;
            }
            set
            {
                this.reminder = value;
            }
        }
    }
}
