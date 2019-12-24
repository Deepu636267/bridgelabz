using BusinessManager.Interfaces;
using Common.Models.AdminModels;
using FundooApi.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooApiTesting
{
    class AdminTesting
    {
        [Test]
        public void Register()
        {
            var service = new Mock<IAdminManager>();
            var service1 = new Mock<ILogger<AdminController>>();
            var Controller = new AdminController(service.Object,service1.Object);
            var add = new AdminModel()
            {
                FirstName = "Sachin",
                LastName = "Maurya",
                Email = "deepumaurya07@gmail.com",
                Password = "12345678"
            };
            var data = Controller.AddNewAdminDetails(add);
            Assert.NotNull(data);
            Assert.Pass();
        }
        [Test]
        public void AdminLogin()
        {
            var service = new Mock<IAdminManager>();
            var service1 = new Mock<ILogger<AdminController>>();
            var Controller = new AdminController(service.Object, service1.Object);
            var login = new AdminLoginModel()
            {
                Email = "deepumaurya07@gmail.com",
                Password = "12345678"
            };
            var data = Controller.AdminLogin(login);
            Assert.NotNull(data);
            Assert.Pass();
        }
        [Test]
        public void Update()
        {
            var service = new Mock<IAdminManager>();
            var service1 = new Mock<ILogger<AdminController>>();
            var Controller = new AdminController(service.Object, service1.Object);
            var add = new AdminModel()
            {
                FirstName = "Sachin",
                LastName = "Maurya",
                Email = "deepumaurya07@gmail.com"  
            };
            var data = Controller.UpdateAdminDetails(add);
            Assert.NotNull(data);
            Assert.Pass();
        }
    }
}
