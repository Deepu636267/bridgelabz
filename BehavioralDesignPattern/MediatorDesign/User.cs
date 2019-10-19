// --------------------------------------------------------------------------------------------------------------------
// <copyright file=User.cs" company="Bridgelabz">
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
    /// User is abstract type class
    /// </summary>
    public abstract class User
    {
        protected ChatMediator mediator;
        protected string name;
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="med">The med.</param>
        /// <param name="name">The name.</param>
        public User(ChatMediator med, string name)
        {
            this.mediator = med;
            this.name = name;
        }
        /// <summary>
        /// Sends the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public abstract void send(String msg);
        /// <summary>
        /// Receives the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public abstract void receive(String msg);
    }
}