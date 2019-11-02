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
    }
}
