// --------------------------------------------------------------------------------------------------------------------
// <copyright file=AdminManager.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessManager.Managers
{
    using BusinessManager.Interfaces;
    using Common.Models.AdminModels;
    using Common.Models.UserModels;
    using FundooRepository.Intefaces;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// AdminManager is class for taking request from controller and send them to repository
    /// </summary>
    /// <seealso cref="BusinessManager.Interfaces.IAdminManager" />
    public class AdminManager : IAdminManager
    {
        private readonly IAdminRepository _repository;
        public AdminManager(IAdminRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Adds the admin details.
        /// </summary>
        /// <param name="admin">The admin.</param>
        /// <returns></returns>
        public async Task<string> AddAdminDetails(AdminModel admin)
        {
            await _repository.AddAdminDetails(admin);
            return "Added Succesfull";
        }
    }
}