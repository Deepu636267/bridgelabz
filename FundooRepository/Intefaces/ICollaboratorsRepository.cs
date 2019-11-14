// --------------------------------------------------------------------------------------------------------------------
// <copyright file=ICollaboratorsRepository.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooRepository.Intefaces
{
    using Common.Models.CollaboratorsModel;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    /// <summary>
    /// ICollaboratorsRepository is an inteface for have method of Collaborators Business logic
    /// </summary>
    public interface ICollaboratorsRepository
    {
        Task AddCollaborator(CollaboratorsModel collaborators, string email);
    }
}