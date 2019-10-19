// --------------------------------------------------------------------------------------------------------------------
// <copyright file=ChatMediator.cs" company="Bridgelabz">
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
    /// ChatMediator is a an interface which acts as mediator between all the sendr and reciecver 
    /// </summary>
    public interface ChatMediator
    {
        public void SendMessage(string msg, User user);
        void AddUser(User user);
    }
}