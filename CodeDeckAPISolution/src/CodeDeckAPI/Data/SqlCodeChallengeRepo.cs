using System;
using System.Collections.Generic;
using System.Linq;
using CodeDeckAPI.Models;

namespace CodeDeckAPI.Data
{
    public class SqlCodeCardRepo : ICodeCardRepo
    {
        private readonly CodeCardContext _context;

        public SqlCodeCardRepo(CodeCardContext context)
        {
            _context = context;
        }

        public void CreateCodeCard(CodeCard cc)
        {
            if(cc == null)
            {
                throw new ArgumentNullException(nameof(cc));
            }

            _context.CodeCards.Add(cc);
        }

        public IEnumerable<CodeCard> GetAllCards()
        {
            return _context.CodeCards.ToList();
        }

        public CodeCard GetCodeCardById(int id)
        {
            return _context.CodeCards.FirstOrDefault(p => p.CardId == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCodeCard(CodeCard cc)
        {
            // Nothing
        }
    }
}