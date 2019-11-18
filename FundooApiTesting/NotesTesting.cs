// --------------------------------------------------------------------------------------------------------------------
// <copyright file=NotesTesting.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooApiTesting
{
    using BusinessManager.Interfaces;
    using Common.Models.NotesModels;
    using FundooApi.Controllers;
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Text;
    /// <summary>
    /// NotesTesting is class for test the Our Notes Api
    /// </summary>
    class NotesTesting
    {
        /// <summary>
        /// Registers this instance will be tested.
        /// </summary>
        [Test]
        public void Register()
        {
            var service = new Mock<INotesManager>();
            var Controller = new NotesController(service.Object);
            var add = new NotesModel()
            {
                Email = "deepumaurya07@gmail.com",
                Title = "Home",
                Description = "Call",
                CreatedDate = DateTime.Now
            };
            var data = Controller.Create(add);
            Assert.NotNull(data);
            Assert.Pass();
        }
        /// <summary>
        /// Shows this instance will be tested.
        /// </summary>
        [Test]
        public void Show()
        {
            var service = new Mock<INotesManager>();
            var Controller = new NotesController(service.Object);
            var data = Controller.Show();
            Assert.NotNull(data);
            Assert.Pass();
        }
        /// <summary>
        /// Deletes this instance will be tested.
        /// </summary>
        [Test]
        public void Delete()
        {
            var service = new Mock<INotesManager>();
            var Controller = new NotesController(service.Object);
            var data = Controller.Delete(2);
            Assert.NotNull(data);
            Assert.Pass();
        }
        /// <summary>
        /// Updates this instance will be tested.
        /// </summary>
        [Test]
        public void Update()
        {
            var service = new Mock<INotesManager>();
            var Controller = new NotesController(service.Object);
            var add = new NotesModel()
            {
                Title = "College",
                Description="Meeting"
            };
            var data = Controller.Update(add);
            Assert.NotNull(data);
            Assert.Pass();
        }
        /// <summary>
        /// Archieves this instance will be tested.
        /// </summary>
        [Test]
        public void Archieve()
        {
            var service = new Mock<INotesManager>();
            var Controller = new NotesController(service.Object);
            var data = Controller.Archive(1009);
            Assert.NotNull(data);
            Assert.Pass();
        }
        /// <summary>
        /// Uns the archieve will be tested.
        /// </summary>
        [Test]
        public void UnArchieve()
        {
            var service = new Mock<INotesManager>();
            var Controller = new NotesController(service.Object);
            var data = Controller.UnArchive(1009);
            Assert.NotNull(data);
            Assert.Pass();
        }
        /// <summary>
        /// Pins this instance will be tested.
        /// </summary>
        [Test]
        public void Pin()
        {
            var service = new Mock<INotesManager>();
            var Controller = new NotesController(service.Object);
            var data = Controller.Pin(1009);
            Assert.NotNull(data);
            Assert.Pass();
        }
        /// <summary>
        /// Uns the pin will be tested.
        /// </summary>
        [Test]
        public void UnPin()
        {
            var service = new Mock<INotesManager>();
            var Controller = new NotesController(service.Object);
            var data = Controller.UnPin(1009);
            Assert.NotNull(data);
            Assert.Pass();
        }
        /// <summary>
        /// Trashes this instance will be tested.
        /// </summary>
        [Test]
        public void Trash()
        {
            var service = new Mock<INotesManager>();
            var Controller = new NotesController(service.Object);
            var data = Controller.Trash(1009);
            Assert.NotNull(data);
            Assert.Pass();
        }
        /// <summary>
        /// Restores the by identifier will be tested.
        /// </summary>
        [Test]
        public void RestoreById()
        {
            var service = new Mock<INotesManager>();
            var Controller = new NotesController(service.Object);
            var data = Controller.RestoreById(1009);
            Assert.NotNull(data);
            Assert.Pass();
        }
        [Test]
        public void SetColor()
        {
            var service = new Mock<INotesManager>();
            var Controller = new NotesController(service.Object);
            var add = new NotesModel()
            {
                Id = 1,
                Color = "Red"

            };
            var data = Controller.SetColor(add);
            Assert.NotNull(data);
            Assert.Pass();
        }
    }
}