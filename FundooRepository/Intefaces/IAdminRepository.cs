// --------------------------------------------------------------------------------------------------------------------
// <copyright file=IAdminRepository.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FundooRepository.Intefaces
{
    using Common.Models.AdminModels;
    using Common.Models.UserModels;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// IAdminRepository is an interface
    /// </summary>
    public interface IAdminRepository
    {
        Task<bool> AddAdminDetails(AdminModel admin);
        Task<bool> AddUserDetails(UserModel model, DateTime date);
        Task<bool> AdminLogin(AdminLoginModel loginModel);
        Task<List<AdminUserDetailsModel>> Details();
    }
}