// --------------------------------------------------------------------------------------------------------------------
// <copyright file=IAccountManager.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace BusinessManager.Interfaces
{
    using Common.Models.UserModels;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    /// <summary>
    /// IAccountManager is an inteface for manager class
    /// </summary>
    public interface IAccountManager
    {
        Task<string> Registration(UserModel user);
        Task<string> UserLogin(LoginModel login);
        Task<string> UserResetPassword(ResetPasswordModel reset);
        Task<string> UserForgetPassword(ForgetPasswordModel forget);
        Task<UserModel> FindByEmailAsync(string email);
        Task<string> ProfilePicUpload(IFormFile file, string email);
        Task<string> LogOut(string key1, string key2);
    }
}