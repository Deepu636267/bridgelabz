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
    }
}
