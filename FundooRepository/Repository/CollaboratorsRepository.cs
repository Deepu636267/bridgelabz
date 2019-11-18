// --------------------------------------------------------------------------------------------------------------------
// <copyright file=CollaboratorsRepository.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooRepository.Repository
{
    using Common.Models.CollaboratorsModel;
    using FundooRepository.Context;
    using FundooRepository.Intefaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    /// <summary>
    /// CollaboratorsRepository is class which inherit the ICollaboratorsRepository interface
    /// </summary>
    /// <seealso cref="FundooRepository.Intefaces.ICollaboratorsRepository" />
    public class CollaboratorsRepository : ICollaboratorsRepository
    {
        private readonly UserContext _context;
        /// <summary>
        /// Initializes a new instance of the <see cref="CollaboratorsRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public CollaboratorsRepository(UserContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Adds the collaborator.
        /// </summary>
        /// <param name="collaborators">The collaborators.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public Task AddCollaborator(CollaboratorsModel collaborators, string email)
        {
            var check = _context.Users.Where(c => c.Email == collaborators.ReciverEamil).FirstOrDefault();
            if (check != null)
            {
                var result = _context.collaborators.Where(i => i.NoteId == collaborators.NoteId).ToList();
                if (result.Count != 0)
                {
                    foreach (var list in result)
                    {
                        if (list.ReciverEamil.Equals(collaborators.ReciverEamil))
                        {
                            return null;
                        }
                    }
                    Add(collaborators, email);
                    return Task.Run(() => _context.SaveChanges());
                }
                else
                {
                    Add(collaborators, email);
                    return Task.Run(() => _context.SaveChanges());
                }
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Adds the specified collaborators.
        /// </summary>
        /// <param name="collaborators">The collaborators.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public Task<bool> Add(CollaboratorsModel collaborators,string email)
        {
            var add = new CollaboratorsModel()
            {
                NoteId = collaborators.NoteId,
                SenderEmail = email,
                ReciverEamil = collaborators.ReciverEamil
            };
           _context.collaborators.Add(add);
            return Task.Run(()=> true);
        }
        /// <summary>
        /// Removes the collaborator.
        /// </summary>
        /// <param name="collaborators">The collaborators.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public Task RemoveCollaborator(CollaboratorsModel collaborators, string email)
        {
            var result = _context.collaborators.Where(c => (c.NoteId == collaborators.NoteId) && (c.ReciverEamil == collaborators.ReciverEamil)).FirstOrDefault();
            if(result.SenderEmail.Equals(email))
            {
                _context.collaborators.Remove(result);
                return Task.Run(() => _context.SaveChanges());
            }
            else
            {
                return null;
            }
            
        }
    }
}
