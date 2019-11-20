// --------------------------------------------------------------------------------------------------------------------
// <copyright file=IAdminManager.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessManager.Interfaces
{
    using Common.Models.AdminModels;
    using Common.Models.UserModels;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// IAdminManager is an interface
    /// </summary>
    public interface IAdminManager
    {
        Task<string> AddAdminDetails(AdminModel admin);
        Task<string> AdminLogin(AdminLoginModel loginModel);
        Task<List<AdminUserDetailsModel>> Details();
    }
}