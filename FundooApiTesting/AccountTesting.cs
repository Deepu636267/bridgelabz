// --------------------------------------------------------------------------------------------------------------------
// <copyright file=AccountTesting.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooApiTesting
{
    using BusinessManager.Interfaces;
    using Common.Models.UserModels;
    using FundooApi.Controllers;
    using Moq;
    using NUnit.Framework;
    /// <summary>
    /// AccountTesting is a class for test the AccountController
    /// </summary>
    public class AccountTesting
    {
        /// <summary>
        /// Registers this instance will be tested.
        /// </summary>
        [Test]
        public void Register()
        {
            var service = new Mock<IAccountManager>();
            var Controller = new AccountController(service.Object);
            var add = new UserModel()
            {
                FirstName = "Sachin",
                LastName = "Maurya",
                Email = "deepumaurya027@gmail.com",
                Password = "1234567890",
                CardType = "advance"
            };
            var data = Controller.Register(add);
            Assert.NotNull(data);
            Assert.Pass();
        }
        /// <summary>
        /// Logins this instance will be tested.
        /// </summary>
        [Test]
        public void Login()
        {
            var service = new Mock<IAccountManager>();
            var Controller = new AccountController(service.Object);
            var add = new LoginModel()
            {
                Email = "deepumaurya07@gmail.com"
            };
            var data = Controller.LogIn(add);
            Assert.NotNull(data);
            Assert.Pass();
        }
        /// <summary>
        /// Resets the password will be tested.
        /// </summary>
        [Test]
        public void ResetPassword()
        {
            var service = new Mock<IAccountManager>();
            var Controller = new AccountController(service.Object);
            var add = new ResetPasswordModel()
            {
                Email = "deepumaurya07@gmail.com",
                OldPassword = "12345678"

            };
            //var data = Controller.ResetPassword(add);
            //Assert.NotNull(data);
            Assert.Pass();
        }
        /// <summary>
        /// Forgets the password will be tested.
        /// </summary>
        [Test]
        public void ForgetPassword()
        {
            var service = new Mock<IAccountManager>();
            var Controller = new AccountController(service.Object);
            var add = new ForgetPasswordModel()
            {
                Email="deepumaurya07@gmail.com" 
                
            };
            var data = Controller.ForgetPassword(add);
            Assert.NotNull(data);
            Assert.Pass();
        }
    }
}