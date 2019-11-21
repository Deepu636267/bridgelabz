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

        /// <summary>
        /// Admins the login.
        /// </summary>
        /// <param name="loginModel">The login model.</param>
        /// <returns></returns>
        public async Task<string> AdminLogin(AdminLoginModel loginModel)
        {
            var result=await _repository.AdminLogin(loginModel);
            if (result == true)
                return "Login SuccesFull";
            else
                return null;
        }

        /// <summary>
        /// Detailses this instance.
        /// </summary>
        /// <returns></returns>
        public async Task<List<AdminUserDetailsModel>> Details()
        {
            var result = await _repository.Details();
            return result;
            
        }

        /// <summary>
        /// Counts this instance.
        /// </summary>
        /// <returns></returns>
        public async Task<string> Count()
        {
            var result = await _repository.Count();
            return result;

        }

        /// <summary>
        /// Updates the admin details by using Procedure and CURSOR.
        /// </summary>
        /// <param name="loginModel">The login model.</param>
        /// <returns></returns>
        public async Task<string> UpdateAdminDetails(AdminModel loginModel)
        {
            var result = await _repository.UpdateAdminDetails(loginModel);
            if (result == true)
                return "Update SuccesFull";
            else
                return null;
        }

        /// <summary>
        /// Adds the new column with batches in TSql For test.
        /// </summary>
        /// <returns></returns>
        public async Task<string> AddNewColoumn()
        {
            var result = await _repository.AddNewColoumn();
            if (result == true)
                return "New Column Added SuccesFull";
            else
                return null;
        }
    }
}