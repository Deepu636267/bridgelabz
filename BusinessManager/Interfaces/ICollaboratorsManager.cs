// --------------------------------------------------------------------------------------------------------------------
// <copyright file=ICollaboratorsManager.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace BusinessManager.Interfaces
{
    using Common.Models.CollaboratorsModel;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    /// <summary>
    /// ICollaboratorsManager is an inteface for have method of Collaborators Manager logic
    /// </summary>
    public interface ICollaboratorsManager
    {
        Task<string> AddCollaboraotors(CollaboratorsModel model, string email);    
        Task<string> RemoveCollaboraotors(CollaboratorsModel model, string email);    
    }
}