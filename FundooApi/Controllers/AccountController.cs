// --------------------------------------------------------------------------------------------------------------------
// <copyright file=AccountController.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using BusinessManager.Interfaces;
    using Common.Models.UserModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    /// <summary>
    /// AccountController is controller class for all account operation
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountManager _manager;
        // private readonly ApplicationSetting _appsetting;       
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public AccountController(IAccountManager manager)
        {
            _manager = manager;
        }
        /// <summary>
        /// Registers the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Register(UserModel user)
        {
            try
            {
                var result = await _manager.Registration(user);
                return Ok(new { result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Logs the in.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LogIn(LoginModel login)
        {
            try
            {
                var result = await _manager.UserLogin(login);
                return Ok(new { result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="reset">The reset.</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [Route("Reset")]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel reset)
        {
            try
            {
                var result = await _manager.UserResetPassword(reset);
                return Ok(new { result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Forgets the password.
        /// </summary>
        /// <param name="forget">The forget.</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
       // [Cached(600)]
        [Route("Forget")]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordModel forget)
        {
            try
            {
                var result = await _manager.UserForgetPassword(forget);
                return Ok(new { result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //[HttpPost]
        //[Route("Log")]
        //public async Task<IActionResult> Log(LoginModel login)
        //{
        //    try
        //    {
        //        var result = await _manager.FindByEmailAsync(login.Email);
        //        if(result!=null)
        //        {
        //            var tokenDescriptor = new SecurityTokenDescriptor
        //            {
        //                Subject = new ClaimsIdentity(new Claim[]
        //                {
        //                    new Claim("Email", result.Email)
        //                }),
        //                Expires = DateTime.UtcNow.AddDays(1),
        //                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appsetting.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
        //            };
        //            var tokenHandler = new JwtSecurityTokenHandler();
        //            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        //            var token = tokenHandler.WriteToken(securityToken);
        //            return Ok(new { token });
        //        }
        //        else
        //        {
        //            return BadRequest(new { message = "Not valid" });
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}        
        /// <summary>
        /// Results this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet, Authorize]
        [Route("reg")]
        public async Task<Object> Result()
        {
            string Email = User.Claims.First(c=> c.Type==ClaimTypes.Email).Value;
            string key = Email.ToUpper();
            var result = await _manager.FindByEmailAsync(Email);
            return new
            {
                result.Email,
                result.Password,
                result.FirstName
            };
        }
        /// <summary>
        /// Profiles the pic upload.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [Route("ProfilePic")]
        public async Task<IActionResult> ProfilePicUpload(IFormFile file)
        {
            string email = User.Claims.First(c => c.Type == "Email").Value;
            try
            {
                var result = await _manager.ProfilePicUpload(file, email);
                if (result != null)
                {
                    return Ok(new { result });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// LogOut the user from a particular seesion
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [Route("LogOut")]
        public async Task<IActionResult> LogOut()
        {
            string email = User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            string key = email.ToUpper();
            try
            {
                var result = await _manager.LogOut(email,key);
                if (result != null)
                {
                    return Ok(new { result });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}