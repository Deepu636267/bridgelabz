using Common.Models.UserModels;
using FundooRepository.Context;
using FundooRepository.Intefaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FundooRepository.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserContext _context;
        private readonly ApplicationSetting _appsetting;
        public AccountRepository(UserContext context, IOptions<ApplicationSetting> appsetting)
        {
            _context = context;
            _appsetting = appsetting.Value;
        }
        public Task Create(UserModel userm)
        {
            try { 
                UserModel user = new UserModel()
                {
                    FirstName = userm.FirstName,
                    LastName = userm.LastName,
                    Email = userm.Email,
                    Password = userm.Password,
                    CardType=userm.CardType

                };
               // _context.Users.Add(user);
               return Task.Run(() => _context.SaveChanges());
            }catch(SqlException ex)
            {
                return Task.FromException(ex);
            }
        }
       
        public Task<string> LogIn(LoginModel login)
        {
            var result = _context.Users.Where(i => i.Email == login.Email && i.Password == login.Password).FirstOrDefault();
            if(result!=null)
            {
                var LoginToken = GenerateToken(result.Email);
                return Task.Run(()=> LoginToken);
            }
            else
            {
                return null;
            }
        }
        public Task ForgetPassword(ForgetPasswordModel forget)
        {
            var result = _context.Users.Where(i => i.Email == forget.Email).FirstOrDefault();
            if(result!=null)
            {
                SendPasswordResetEmail(forget.Email, result.FirstName);
                return Task.Run(() => _context.SaveChanges());
            }
            else
            {
                return null;
            }

        }

        public Task ResetPassword(ResetPasswordModel reset)
        {
            var result = _context.Users.Where(i => i.Email == reset.Email && i.Password==reset.OldPassword).FirstOrDefault();
            if(result!=null)
            {
                result.Password = reset.NewPassword;
                _context.Users.Update(result);
                return Task.Run(() => _context.SaveChanges());
            }
            else
            {
                return null;
            }
        }
        private void SendPasswordResetEmail(string ToEmail, string UserName)
        {
            // MailMessage class is present is System.Net.Mail namespace
            MailMessage mailMessage = new MailMessage("deepumaurya07@gmail.com", ToEmail);
            // StringBuilder class is present in System.Text namespace
            StringBuilder sbEmailBody = new StringBuilder();
            sbEmailBody.Append("Dear " + UserName + ",<br/><br/>");
            sbEmailBody.Append("Please click on the following link to reset your password");
            sbEmailBody.Append("<br/>"); 
            sbEmailBody.Append("http://localhost/WebApplication1/Registration/ChangePassword.aspx?uid=");
            sbEmailBody.Append("<br/><br/>");
            sbEmailBody.Append("<b>FundooApi</b>");
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = sbEmailBody.ToString();
            mailMessage.Subject = "Reset Your Password";
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);  
            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "deepumaurya07@gmail.com",
                Password = "yourpassword"
            };
            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);
        }
        public Task<UserModel> FindByEmailAsync(string email)
        {
            var user =  _context.Users.Find(email);
            return Task.Run(()=>user);
            
        }
        public Task<String> GenerateToken(string Email)
        {
            try
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("Email", Email)
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appsetting.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var cacheKey = Email;
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                //ConnectionMultiplexer connectionMulitplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                //IDatabase database = connectionMulitplexer.GetDatabase();
                //database.StringSet(cacheKey, token.ToString());
                //database.StringGet(cacheKey);
                return Task.Run(()=>token);              
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
