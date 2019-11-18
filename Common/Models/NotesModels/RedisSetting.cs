// --------------------------------------------------------------------------------------------------------------------
// <copyright file=RedisSetting.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace Common.Models.NotesModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    /// <summary>
    /// RedisSetting is class where it can set and get all the host and route value for the cache provider
    /// </summary>
    public class RedisSetting
    {
        /// <summary>
        /// Gets or sets the host.
        /// </summary>
        /// <value>
        /// The host.
        /// </value>
        public string host { get; set; }
        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        /// <value>
        /// The port.
        /// </value>
        public int port { get; set; }
    }
}
