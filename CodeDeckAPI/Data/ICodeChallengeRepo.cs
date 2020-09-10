using System.Collections.Generic;
using CodeDeckAPI.Models;

namespace CodeDeckAPI.Data
{
    public interface ICodeChallengeRepo
    {
         bool SaveChanges();

         IEnumerable<CodeChallenge> GetAllChallenges();

         CodeChallenge GetCodeChallengeById(int id);

         void CreateCodeChallenge(CodeChallenge cc);
         void UpdateCodeChallenge(CodeChallenge cc);
    }
}