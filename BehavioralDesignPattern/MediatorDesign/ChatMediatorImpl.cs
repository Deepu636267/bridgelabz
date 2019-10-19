// --------------------------------------------------------------------------------------------------------------------
// <copyright file=ChatMediatorImpl.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace DesignPattern.BehavioralDesignPattern.MediatorDesign
{
    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Text;
    /// <summary>
    /// ChatMediatorImpl is class which inherit the ChatMediator
    /// </summary>
    /// <seealso cref="DesignPattern.BehavioralDesignPattern.MediatorDesign.ChatMediator" />
    public class ChatMediatorImpl : ChatMediator
    {
        public List<User> users;
        /// <summary>
        /// Initializes a new instance of the <see cref="ChatMediatorImpl"/> class.
        /// </summary>
        public ChatMediatorImpl()
        {
            this.users = new List<User>();
        }
        /// <summary>
        /// Adds the user.
        /// </summary>
        /// <param name="user">The user.</param>
        public void AddUser(User user)
        {
            this.users.Add(user);
        }
        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="user">The user.</param>
        public void SendMessage(String msg, User user)
        {
            foreach (User u in this.users)
            {
                //message should not be received by the user sending it
                if (u != user)
                {
                    u.receive(msg);
                }
            }
        }
    }
}