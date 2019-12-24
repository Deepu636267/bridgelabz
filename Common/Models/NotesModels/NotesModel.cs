// --------------------------------------------------------------------------------------------------------------------
// <copyright file=NotesModel.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace Common.Models.NotesModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;
    using Common.Models.CollaboratorsModel;
    /// <summary>
    /// NotesModel is class which has basic structure of notes
    /// </summary>
    public class NotesModel
    {

        /// <summary>
        /// The identifier
        /// </summary>
        private int id;
        /// <summary>
        /// The email
        /// </summary>
        private string email;
        /// <summary>
        /// The title
        /// </summary>
        private string title;
        /// <summary>
        /// The description
        /// </summary>
        private string description;
        /// <summary>
        /// The created date
        /// </summary>
        private DateTime? createdDate;
        /// <summary>
        /// The modified date
        /// </summary>
        private DateTime? modifiedDate;
        /// <summary>
        /// The images
        /// </summary>
        private string images;
        /// <summary>
        /// The reminder
        /// </summary>
        private string reminder;
        /// <summary>
        /// The is archive
        /// </summary>
        private bool isArchive;
        /// <summary>
        /// </summary>
        private bool isTrash;
        /// <summary>
        /// The is pin
        /// </summary>
        private bool isPin;
        /// <summary>
        /// The color
        /// </summary>
        private string color;
        /// <summary>
        /// The index value
        /// </summary>
        private int indexValue;
        private int collaboratorId;

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        public int Id 
        {
            get { return this.id; }
            set { this.id = value; }
        }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [ForeignKey("UserModel")]
        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }
        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>
        /// The created date.
        /// </value>
        public DateTime? CreatedDate
        {
            get { return this.createdDate; }
            set { this.createdDate = value; }
        }
        /// <summary>
        /// Gets or sets the modified date.
        /// </summary>
        /// <value>
        /// The modified date.
        /// </value>
        public DateTime? ModifiedDate
        {
            get { return this.modifiedDate; }
            set { this.modifiedDate = value; }
        }
        /// <summary>
        /// Gets or sets the images.
        /// </summary>
        /// <value>
        /// The images.
        /// </value>
        public string Images
        {
            get { return this.images; }
            set { this.images = value; }
        }
        /// <summary>
        /// Gets or sets the reminder.
        /// </summary>
        /// <value>
        /// The reminder.
        /// </value>
        public string Reminder
        {
            get { return this.reminder; }
            set { this.reminder = value; }
        }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is archive.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is archive; otherwise, <c>false</c>.
        /// </value>
        public bool IsArchive
        {
            get { return this.isArchive; }
            set { this.isArchive = value; }
        }
        public bool IsPin
        {
            get { return this.isPin; }
            set { this.isPin = value; }
        }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is trash.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is trash; otherwise, <c>false</c>.
        /// </value>
        public bool IsTrash
        {
            get { return this.isTrash; }
            set { this.isTrash = value; }
        }
        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>
        /// The color.
        /// </value>
        public string Color
        {
            get { return this.color; }
            set { this.color = value; }
        }
        /// <summary>
        /// Gets or sets the index value.
        /// </summary>
        /// <value>
        /// The index value.
        /// </value>
        public int IndexValue
        {
            get { return this.indexValue; }
            set { this.indexValue = value; }
        }
        public int CollaboratorId
        {
            get { return this.collaboratorId; }
            set { this.collaboratorId = value; }
        }
        ///// <summary>
        ///// Gets or sets the collaborators.
        ///// </summary>
        ///// <value>
        ///// The collaborators.
        ///// </value>
        //public virtual CollaboratorsModel Collaborators { get; set; }
    }
}