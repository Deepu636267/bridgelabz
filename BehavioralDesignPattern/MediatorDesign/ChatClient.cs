// --------------------------------------------------------------------------------------------------------------------
// <copyright file=ChatClient.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace DesignPattern.BehavioralDesignPattern.MediatorDesign
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    /// <summary>
    /// ChatClient is a class it has definition of how to chat proceess is operate by user
    /// </summary>
    public class ChatClient
    {
        /// <summary>
        /// Chats the start.
        /// </summary>
        public void ChatStart()
        {
            ChatMediator mediator = new ChatMediatorImpl();
            User user1 = new UserImpl(mediator, "Pankaj");
            User user2 = new UserImpl(mediator, "Lisa");
            User user3 = new UserImpl(mediator, "Saurabh");
            User user4 = new UserImpl(mediator, "David");
            mediator.AddUser(user1);
            mediator.AddUser(user2);
            mediator.AddUser(user3);
            mediator.AddUser(user4);
            user1.send("Hi All");
            user2.send("Hi Bro");
        }
    }
}