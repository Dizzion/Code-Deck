using System.Collections.Generic;
using System.Linq;
using CodeDeckAPI.Models;

namespace CodeDeckAPI.Data
{
    public class SqlCodeChallengeRepo : ICodeChallengeRepo
    {
        private readonly CodeChallengeContext _context;

        public SqlCodeChallengeRepo(CodeChallengeContext context)
        {
            _context = context;
        }

        public IEnumerable<CodeChallenge> GetAllChallenges()
        {
            return _context.CodeChallenges.ToList();
        }

        public CodeChallenge GetCodeChallengeById(int id)
        {
            return _context.CodeChallenges.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}