// --------------------------------------------------------------------------------------------------------------------
// <copyright file=NotesRepository.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooRepository.Repository
{
    using Common.Models.NotesModels;
    using FundooRepository.Context;
    using FundooRepository.Intefaces;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    /// <summary>
    /// NotesRepository is a class which inherited the INotesRepository
    /// </summary>
    public class NotesRepository:INotesRepository
    {
        private readonly UserContext _context;
        public NotesRepository(UserContext context)
        {
            _context = context;
        }

        public Task Create(NotesModel notes)
        {
            throw new NotImplementedException();
        }
    }
}
