// --------------------------------------------------------------------------------------------------------------------
// <copyright file=UserImpl.cs" company="Bridgelabz">
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
    /// UserImpl is a class which inherit the behaviour of User abstract class method 
    /// </summary>
    /// <seealso cref="DesignPattern.BehavioralDesignPattern.MediatorDesign.User" />
    public class UserImpl : User
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserImpl"/> class.
        /// </summary>
        /// <param name="med">The med.</param>
        /// <param name="name">The name.</param>
        public UserImpl(ChatMediator med,string name): base(med,name)
        {
        }
        /// <summary>
        /// Sends the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public override void send(string msg)
        {
            Console.WriteLine(this.name + ": Sending Message=" + msg);
            mediator.SendMessage(msg, this);
        }
        /// <summary>
        /// Receives the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public override void receive(string msg)
        {
          Console.WriteLine(this.name + ": Received Message:" + msg);
        }
    }
}