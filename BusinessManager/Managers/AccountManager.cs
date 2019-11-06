using BusinessManager.Interfaces;
using Common.Models.UserModels;
using FundooRepository.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Managers
{
    public class AccountManager : IAccountManager
    {
        private readonly IAccountRepository _repository;
        public AccountManager(IAccountRepository repository)
        {
            _repository = repository;
        }
        public async Task<string> Registration(UserModel user)
        {
             await _repository.Create(user);
            return "Account Created Succesfully";
        }

       

        public async Task<string> UserLogin(LoginModel login)
        {
           var result= await _repository.LogIn(login);
            return result;
        }

        public async Task<string> UserResetPassword(ResetPasswordModel reset)
        {
            await _repository.ResetPassword(reset);
            return "Password change Successfully";
        }
        public async Task<string> UserForgetPassword(ForgetPasswordModel forget)
        {
            await _repository.ForgetPassword(forget);
            return "Email sent Successfully";
        }
        public async Task<UserModel> FindByEmailAsync(string email)
        {
            var result =await _repository.FindByEmailAsync(email);
            return result;
        }
    }
}