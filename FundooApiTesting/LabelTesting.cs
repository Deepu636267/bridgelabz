// --------------------------------------------------------------------------------------------------------------------
// <copyright file=LabelTesting.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooApiTesting
{
    using BusinessManager.Interfaces;
    using Common.Models.LabelsModels;
    using FundooApi.Controllers;
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Text;
    /// <summary>
    /// LabelTesting is a class which test our label Api
    /// </summary>
    class LabelTesting
    {
        /// <summary>
        /// Registers this instance will be used for testing.
        /// </summary>
        [Test]
        public void Register()
        {
            var service = new Mock<ILabelManager>();
            var Controller = new LabelController(service.Object);
            var add = new LabelModel()
            {
                Label="School"
            };
            var data = Controller.Create(add);
            Assert.NotNull(data);
            Assert.Pass();
        }
        /// <summary>
        /// Shows this instance will be used for testing.
        /// </summary>
        [Test]
        public void Show()
        {
            var service = new Mock<ILabelManager>();
            var Controller = new LabelController(service.Object);
            Assert.Pass();
        }
        /// <summary>
        /// Deletes this instance will be used for testing.
        /// </summary>
        [Test]
        public void Delete()
        {
            var service = new Mock<ILabelManager>();
            var Controller = new LabelController(service.Object);
            var data = Controller.Delete(2);
            Assert.NotNull(data);
            Assert.Pass();
        }
        /// <summary>
        /// Updates this instance will be used for testing.
        /// </summary>
        [Test]
        public void Update()
        {
            var service = new Mock<ILabelManager>();
            var Controller = new LabelController(service.Object);
            var add = new LabelModel()
            {
                Label = "College"
            };
            var data = Controller.Update(add);
            Assert.NotNull(data);
            Assert.Pass();
        }
    }
}