using Common.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FundooRepository.Intefaces
{
    public interface IAccountRepository
    {
        Task Create(UserModel userm);
        Task<string> LogIn(LoginModel login);
        Task ResetPassword(ResetPasswordModel reset);
        Task ForgetPassword(ForgetPasswordModel forget);
        Task<UserModel> FindByEmailAsync(string email);
        Task<String> GenerateToken(string Email);
    }
}
