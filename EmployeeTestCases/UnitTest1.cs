using EmployementManagementSystem.Controllers;
using EmployementManagementSystem.Manager;
using EmployementManagementSystem.Model;
using Moq;
using NUnit.Framework;
using System.Transactions;

namespace EmployeeTestCases
{
    public class Tests
    {
        [Test]
        public void CreateTest()
        {
            var service = new Mock<IEmployeeManager>();
            var controller = new EmployeeController(service.Object);
            var add = new EmployeeModel()
            {
                EmpName = "Sachin",
                Designation = "Developer",
                Gender = "male",
                Email = "abc@gmail.com",
                EmpPassword = "23456",
                Address = "btm"
            };
            var data = controller.Create(add);
            Assert.NotNull(data);
            Assert.Pass("Added Successfully");
        }
        [Test]
        public void DeleteTest()
        {
            var service = new Mock<IEmployeeManager>();
            var controller = new EmployeeController(service.Object);
            var add = new EmployeeModel()
            {
                EmpId = 1003
            };
            var data = controller.ActionDelete(add);
            Assert.NotNull(data);
            Assert.Pass(data.ToString());
        }
        [Test]
        public void UpdateTest()
        {
            var service = new Mock<IEmployeeManager>();
            var controller = new EmployeeController(service.Object);
            var add = new EmployeeModel()
            {
                EmpId = 1003,
                EmpName = "Sachin",
                Designation = "Developer",
                Gender = "male",
                Email = "abc@gmail.com",
                EmpPassword = "23456",
                Address = "btm"
            };
            var data = controller.Update(add);
            Assert.NotNull(data);
        }
        [Test]
        public void LoginTest()
        {
            var service = new Mock<IEmployeeManager>();
            var controller = new EmployeeController(service.Object);
            var add = new EmployeeModel()
            {
                EmpName = "Sachin",
                EmpPassword = "23456"
            };
            var data = controller.Index(add);
            Assert.NotNull(data);
        }
        [Test]
        public void DeleteTest1()
        {
            var service = new Mock<IEmployeeManager>();
            var controller = new EmployeeController(service.Object);
            var add = new EmployeeModel()
            {
                EmpId = 1003
            };
            var data = controller.ActionDelete(add);
           // Assert.NotNull(data);
            Assert.Pass(data.ToString());
        }
    }
}