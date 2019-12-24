// --------------------------------------------------------------------------------------------------------------------
// <copyright file=IAccountRepository.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooRepository.Intefaces
{
    using Common.Models.UserModels;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    /// <summary>
    /// IAccountRepository is an inteface
    /// </summary>
    public interface IAccountRepository
    {
        Task Create(UserModel userm);
        Task<string> LogIn(LoginModel login);
        Task<string> FacebookLogIn(UserModel login);
        Task<string> GoogleLogIn(UserModel login);
        Task ChangePassword(ResetPasswordModel reset, string email);
        Task<string> ForgetPassword(ForgetPasswordModel forget);
        Task<UserModel> FindByEmailAsync(string email);
        Task<bool> ProfilePicUpload(IFormFile file, string email);
        Task<bool> LogOut(string key1, string key2);
        Task ResetPassword(ResetPasswordModel reset, string email, string cardType);
    }
}