using BusinessManager.Interfaces;
using Common.Models.NotesModels;
using FundooRepository.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Managers
{
    public class NotesManager : INotesManager
    {
        private readonly INotesRepository repository;
        public NotesManager(INotesRepository _repository)
        {
            repository = _repository;
        }
        public async Task<string> Create(NotesModel notes, string email)
        {
            await repository.Create(notes, email);
            return "Added Succesfully";
        }
    }
}
