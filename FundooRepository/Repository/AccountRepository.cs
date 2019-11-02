using Common.Models.UserModels;
using FundooRepository.Context;
using FundooRepository.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FundooRepository.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserContext _context;
        public AccountRepository(UserContext context)
        {
            _context = context;
        }
        public Task Create(UserModel userm)
        {
            UserModel user = new UserModel()
            {
                FirstName = userm.FirstName,
                LastName = userm.LastName,
                Email = userm.Email,
                Password = userm.Password
            };
            _context.Users.Add(user);
           return Task.Run(()=>_context.SaveChanges());
            
        }
    }
}
