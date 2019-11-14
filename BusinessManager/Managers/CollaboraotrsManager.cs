// --------------------------------------------------------------------------------------------------------------------
// <copyright file=CollaboraotrsManager.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace BusinessManager.Managers
{
    using BusinessManager.Interfaces;
    using Common.Models.CollaboratorsModel;
    using FundooRepository.Intefaces;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    /// <summary>
    /// CollaboraotrsManager is a class which inherit the ICollaboratorsManager inteface
    /// </summary>
    /// <seealso cref="BusinessManager.Interfaces.ICollaboratorsManager" />
    public class CollaboraotrsManager : ICollaboratorsManager
    {
        private readonly ICollaboratorsRepository _repository;
        /// <summary>
        /// Initializes a new instance of the <see cref="CollaboraotrsManager"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public CollaboraotrsManager(ICollaboratorsRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Adds the collaboraotors.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public async Task<string> AddCollaboraotors(CollaboratorsModel model, string email)
        {
            await _repository.AddCollaborator(model, email);
            return "Added Successfully";
        }
    }
}