using Common.Models.NotesModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Interfaces
{
    public interface INotesManager
    {
       Task<string> Create(NotesModel notes, string email);
    }
}
