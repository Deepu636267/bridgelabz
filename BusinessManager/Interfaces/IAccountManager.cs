using Common.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Interfaces
{
    public interface IAccountManager
    {
        Task<string> Registration(UserModel user);
        Task<string> UserLogin(LoginModel login);
        Task<string> UserResetPassword(ResetPasswordModel reset);
        Task<string> UserForgetPassword(ForgetPasswordModel forget);
        Task<UserModel> FindByEmailAsync(string email);
    }
}
