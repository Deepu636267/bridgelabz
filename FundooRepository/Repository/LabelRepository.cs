// --------------------------------------------------------------------------------------------------------------------
// <copyright file=LabelRepository.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooRepository.Repository
{
    using Common.Models.LabelsModels;
    using FundooRepository.Context;
    using FundooRepository.Intefaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class LabelRepository:ILabelRepository
    {
        private readonly UserContext _context;
        public LabelRepository(UserContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Creates the specified model with Jwt Authentication . 
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        public Task Create(LabelModel model, string email)
        {
            model.Email = email;
            var note = new LabelModel()
            {
                NoteId=model.NoteId,
                Email = model.Email,
                Label = model.Label
            };
             _context.Labels.Add(note);
            return Task.Run(() => _context.SaveChanges());
        }
        /// <summary>
        /// Deletes the specified identifier with Jwt Authentication .
        /// </summary>
        /// <param name="ID">The identifier.</param>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        public Task Delete(string label, string Email)
        {
            IEnumerable<LabelModel> result = _context.Labels.Where(i => i.Label == label && i.Email==Email).ToList();
            if (result != null)
            {
                _context.Labels.RemoveRange(result);
                return Task.Run(() => _context.SaveChanges());
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Shows the specified email with Jwt Authentication .
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        public Task<List<LabelModel>> Show(string Email)
        {
            var result = _context.Labels.Where(i => i.Email == Email).GroupBy(o=>new { o.Label }).Select(o=>o.FirstOrDefault());
            var result1=result.ToList();
            return Task.Run(()=>result1);
        }
        /// <summary>
        /// Updates the specified model with Jwt Authentication .
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        public Task Update(string label, int id,string Email)
        {
            var labelName = _context.Labels.Where(i => i.ID == id && i.Email == Email).FirstOrDefault();
            IEnumerable<LabelModel> result = _context.Labels.Where(i => i.Label == labelName.Label && i.Email == Email).ToList();
            if (result != null)
            {
                foreach(var list in result)
                {
                    list.Label = label;
                }
                _context.Labels.UpdateRange(result);
                   
               
                return Task.Run(() => _context.SaveChanges());
            }
            else
            {
                return null;
            }
        }
    }
}