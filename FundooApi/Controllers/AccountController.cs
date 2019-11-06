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

namespace FundooApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountManager _manager;
       // private readonly ApplicationSetting _appsetting;
        public AccountController(IAccountManager manager)
        {
            _manager = manager;
        }
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
        [HttpPost]
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
        [HttpPost]
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

        [HttpGet, Authorize]
      //  [Authorize]
        [Route("reg")]
        public async Task<Object> Result()
        {
            string Email = User.Claims.First(c => c.Type == "Email").Value;
            var result = await _manager.FindByEmailAsync(Email);
            return new
            {
                result.Email,
                result.Password,
                result.FirstName
            };
        }
    }
}