using Common.Models.NotesModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Common.Models.CollaboratorsModel
{
    public class CollaboratorsModel
    {
        private int id;
        private string sednderEmail;
        private int noteId;
        private string reciverEmail;
        [Key]
        public int Id
        {
            get {return this.id; }
            set {this.id=value; }
        }
        [ForeignKey("UserModel")]
        public string SenderEmail
        {
            get { return this.sednderEmail; }
            set { this.sednderEmail = value; }
        }
        [ForeignKey("NotesModel")]
        public int NoteId
        {
            get { return this.noteId; }
            set { this.noteId = value; }
        }
        [ForeignKey("UserModel")]
        [Required]
        public string ReciverEamil
        {
            get { return this.reciverEmail; }
            set { this.reciverEmail = value; }
        }
     
    }
}