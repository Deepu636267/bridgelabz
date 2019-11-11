// --------------------------------------------------------------------------------------------------------------------
// <copyright file=INotesManager.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace BusinessManager.Interfaces
{
    using Common.Models.NotesModels;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    /// <summary>
    /// INotesManager is an inteface 
    /// </summary>
    public interface INotesManager
    {
        Task<string> Create(NotesModel notes, string email);
        Task<string> Del(int ID, string Email);
        Task<List<NotesModel>> Show(string Email);
        Task<string> Update(NotesModel note, string Email);
        Task<List<NotesModel>> RetrieveById(int Id, string email);
    }
}