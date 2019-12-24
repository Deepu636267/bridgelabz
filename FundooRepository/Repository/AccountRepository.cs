﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file=AccountRepository.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooRepository.Repository
{
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Common.Models.UserModels;
    using FundooRepository.Context;
    using FundooRepository.Intefaces;
    using Microsoft.AspNetCore.Http;
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
    /// <summary>
    /// AccountRepository is class which has inherited the IAccountRepository for all the busineess logic 
    /// </summary>
    /// <seealso cref="FundooRepository.Intefaces.IAccountRepository" />
    public class AccountRepository : IAccountRepository
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly UserContext _context;
        private readonly ApplicationSetting _appsetting;
        private readonly ICacheProvider _cacheProvider;
        private readonly IAdminRepository _repository;
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="appsetting">The appsetting.</param>
        public AccountRepository(UserContext context, IOptions<ApplicationSetting> appsetting, ICacheProvider cacheProvider,IAdminRepository repository)
        {
            _context = context;
            _appsetting = appsetting.Value;
            _cacheProvider = cacheProvider;
            _repository = repository;
        }
        /// <summary>
        /// Creates the specified userm.
        /// </summary>
        /// <param name="userm">The userm.</param>
        /// <returns></returns>
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
               _context.Users.Add(user);
              
                //SetCache(userm.Email);
               return Task.Run(() => _context.SaveChanges());
            }catch(SqlException ex)
            {
                return Task.FromException(ex);
            }
        }
        //public void SetUserValue(string email, string key)
        //{
        //    var result = _context.Users.Where(i => i.Email == email).ToList();
        //    _cacheProvider.Set(key, result);
        //}
        /// <summary>
        /// Logs the in.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns></returns>
        public async Task<string> LogIn(LoginModel login)
        {
            var result = _context.Users.Where(i => i.Email == login.Email && i.Password == login.Password).FirstOrDefault();
            if(result!=null)
            {
                result.Status = "Active";
                _context.SaveChanges();
                await _repository.AddUserDetails(result, DateTime.Now);
                var LoginToken = GenerateToken(result);
                var key = result.ID.ToString() +"_"+ result.Email;
                SetValue(result.Email, key);
                return await Task.Run(()=> LoginToken);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Forgets the password.
        /// </summary>
        /// <param name="forget">The forget.</param>
        /// <returns></returns>
        public Task<string> ForgetPassword(ForgetPasswordModel forget)
        {
            var result = _context.Users.Where(i => i.Email == forget.Email).FirstOrDefault();
            if(result!=null)
            {
                var LoginToken = GenerateToken(result);
                SendPasswordResetEmail(result.Email, result.FirstName,LoginToken);
                return Task.Run(() => LoginToken);
            }
            else
            {
                return null;
            }

        }
        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="reset">The reset.</param>
        /// <returns></returns>
        public Task ChangePassword(ResetPasswordModel reset, string email)
        {
            var result = _context.Users.Where(i => i.Email == email && i.Password==reset.OldPassword).FirstOrDefault();
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

        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="Password">The password.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public Task ResetPassword(ResetPasswordModel reset, string email,string cardType)
        {
            var result = _context.Users.Where(i => i.Email == email).FirstOrDefault();
            if(result!=null)
            {
                result.Password = reset.NewPassword;
                result.CardType = cardType;
                _context.Users.Update(result).Property(x => x.ID).IsModified = false; ;
                return Task.Run(() => _context.SaveChanges());
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Sends the password reset email.
        /// </summary>
        /// <param name="ToEmail">To email.</param>
        /// <param name="UserName">Name of the user.</param>
        public Task SendPasswordResetEmail(string ToEmail, string UserName,string LoginToken)
        {
            // MailMessage class is present is System.Net.Mail namespace
            MailMessage mailMessage = new MailMessage("deepumaurya07@gmail.com", ToEmail);
            // StringBuilder class is present in System.Text namespace
            StringBuilder sbEmailBody = new StringBuilder();
            sbEmailBody.Append("Dear " + UserName + ",<br/><br/>");
            sbEmailBody.Append("Please click on the following link to reset your password");
            sbEmailBody.Append("<br/>"); 
            sbEmailBody.Append("http://localhost:3001/reset/"+ LoginToken);
            sbEmailBody.Append("<br/><br/>");
            sbEmailBody.Append("<b>FundooApi</b>");
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = sbEmailBody.ToString();
            mailMessage.Subject = "Reset Your Password";
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);  
            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "deepumaurya07@gmail.com",
                Password = "sachin@aryan"
            };
            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);
            smtpClient.Dispose();
            return null;
        }
        /// <summary>
        /// Finds the by email asynchronous.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public Task<UserModel> FindByEmailAsync(string email)
        {
            var user =  _context.Users.Find(email);
            return Task.Run(()=>user);
            
        }
        /// <summary>
        /// Generates the token.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        public String GenerateToken(UserModel result)
        {
            try
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Email, result.Email),
                        new Claim(ClaimTypes.UserData, result.ID.ToString())


                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appsetting.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                _cacheProvider.Set(result.Email, token);       
                return token;              
            }
            catch (Exception)
            {
                return null;
            }
         }
        /// <summary>
        /// Profiles the pic upload.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Task<bool> ProfilePicUpload(IFormFile file, string email)
        {
            var path = file.OpenReadStream();
            var File = file.FileName;
            CloudinaryDotNet.Account account = new CloudinaryDotNet.Account("dtil5iw6l", "562314371245223", "rvy_ZB_bMoq7pva8whrFXOcBprI");
            CloudinaryDotNet.Cloudinary cloudinary = new CloudinaryDotNet.Cloudinary(account);
            var image = new ImageUploadParams()
            {
                File = new FileDescription(File,path)
            };
            var uploadResult = cloudinary.Upload(image);
            if (uploadResult.Error != null)
                throw new Exception(uploadResult.Error.Message);
            var result = _context.Users.Where(i => i.Email == email).FirstOrDefault();
            if (result != null)
            {
               result.ProfilePic = uploadResult.Uri.ToString();
               try
               {
                   var value = Task.Run(() => _context.SaveChanges());
               }
               catch (Exception)
               {
                   return Task.Run(() => false);
               }
               return Task.Run(() => true);
            }
            else
            {
                return Task.Run(() => false);
            }
        }
        /// <summary>
        /// SetValue the valuein a particular key in redis cache
        /// </summary>
        /// <param name="email"></param>
        /// <param name="key"></param>
        public void SetValue(string email,string key)
        {
            var result = _context.Notes.Where(i => i.Email == email).ToList();
            if (result.Count != 0)
            {
                _cacheProvider.Set(key, result);
            }
            else
            {
                return;
            }
        }
        /// <summary>
        /// LogOut the user and remove its all keys from redis cahche
        /// </summary>
        /// <param name="key1"></param>
        /// <param name="key2"></param>
        /// <returns></returns>
        public Task<bool> LogOut(string key1,string key2)
        {
            _cacheProvider.Remove(key1);
            var result = _context.Users.Where(i => i.Email == key1).FirstOrDefault();
            result.Status = "In-Active";
            _context.SaveChanges();
            _cacheProvider.Remove(key2);
            return Task.Run(() => true);
        }
        public void SetCache(string email)
        {
            if (_cacheProvider.IsInCache("User"))
            {
                var result = _context.Users.Where(i => i.Email == email).First();
                var value = _cacheProvider.Get<List<UserModel>>("User");
                value.Add(result);
                _cacheProvider.Set("User", value);
                return;
            }
            else
            {
                var result = _context.Users.Where(i => i.Email == email).ToList();
                _cacheProvider.Set("User", result);
                return;
            }
        }
        public async Task<string> FacebookLogIn(UserModel user)
        {
            var result = _context.Users.Where(i => i.Email == user.Email).FirstOrDefault();
            if (result != null)
            {
                result.Status = "Facebook-Active";
                _context.SaveChanges();
                await _repository.AddUserDetails(result, DateTime.Now);
                var LoginToken = GenerateToken(result);
                var key = result.ID.ToString() + "_" + result.Email;
                SetValue(result.Email, key);
                return await Task.Run(() => LoginToken);
            }
            else
            {
                UserModel userm = new UserModel()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password=user.Password,
                    CardType = user.CardType
                };
                _context.Users.Add(userm);
                _context.SaveChanges();
                result.Status = "Facebook-Active";
                _context.SaveChanges();
                await _repository.AddUserDetails(result, DateTime.Now);
                var LoginToken = GenerateToken(result);
                var key = result.ID.ToString() + "_" + result.Email;
                SetValue(result.Email, key);
                return await Task.Run(() => LoginToken);
            }
        }
        public async Task<string> GoogleLogIn(UserModel user)
        {
            var result = _context.Users.Where(i => i.Email == user.Email).FirstOrDefault();
            if (result != null)
            {
                result.Status = "Google-Active";
                _context.SaveChanges();
                await _repository.AddUserDetails(result, DateTime.Now);
                var LoginToken = GenerateToken(result);
                var key = result.ID.ToString() + "_" + result.Email;
                SetValue(result.Email, key);
                return await Task.Run(() => LoginToken);
            }
            else
            {
                UserModel userm = new UserModel()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password=user.Password,
                    CardType = user.CardType,
                    Status="Google-Active"
                };
                _context.Users.Add(userm);
                _context.SaveChanges();
               // result.Status = "Google-Active";
                _context.SaveChanges();
                await _repository.AddUserDetails(user, DateTime.Now);
                var LoginToken = GenerateToken(user);
                //var key = result.ID.ToString() + "_" + result.Email;
                //SetValue(result.Email, key);
                return await Task.Run(() => LoginToken);
            }
        }
    }
}