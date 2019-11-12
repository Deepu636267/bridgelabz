﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file=AccountManager.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace BusinessManager.Managers
{
    using BusinessManager.Interfaces;
    using Common.Models.UserModels;
    using FundooRepository.Intefaces;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    /// <summary>
    /// AccountManager is a class which inherited the IAccountManager
    /// </summary>
    /// <seealso cref="BusinessManager.Interfaces.IAccountManager" />
    public class AccountManager : IAccountManager
    {
        private readonly IAccountRepository _repository;
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountManager"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public AccountManager(IAccountRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Registrations the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public async Task<string> Registration(UserModel user)
        {
             await _repository.Create(user);
            return "Account Created Succesfully";
        }
        /// <summary>
        /// Users the login.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns></returns>
        public async Task<string> UserLogin(LoginModel login)
        {
           var result= await _repository.LogIn(login);
            return result;
        }
        /// <summary>
        /// Users the reset password.
        /// </summary>
        /// <param name="reset">The reset.</param>
        /// <returns></returns>
        public async Task<string> UserResetPassword(ResetPasswordModel reset)
        {
            await _repository.ResetPassword(reset);
            return "Password change Successfully";
        }
        /// <summary>
        /// Users the forget password.
        /// </summary>
        /// <param name="forget">The forget.</param>
        /// <returns></returns>
        public async Task<string> UserForgetPassword(ForgetPasswordModel forget)
        {
            await _repository.ForgetPassword(forget);
            return "Email sent Successfully";
        }
        /// <summary>
        /// Finds the by email asynchronous.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public async Task<UserModel> FindByEmailAsync(string email)
        {
            var result =await _repository.FindByEmailAsync(email);
            return result;
        }
    }
}