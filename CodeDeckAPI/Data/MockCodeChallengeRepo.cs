using System.Collections.Generic;
using CodeDeckAPI.Models;

namespace CodeDeckAPI.Data
{
    public class MockCodeChallengeRepo : ICodeChallengeRepo
    {
        public void CreateCodeChallenge(CodeChallenge cc)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<CodeChallenge> GetAllChallenges()
        {
            var codeChallenges = new List<CodeChallenge>
            {
                new CodeChallenge{Id=0, ChallengeCode="urlhere"},
                new CodeChallenge{Id=1, ChallengeCode="urlhere"},
                new CodeChallenge{Id=2, ChallengeCode="urlhere"}
            };

            return codeChallenges;
        }

        public CodeChallenge GetCodeChallengeById(int id)
        {
            return new CodeChallenge{Id=0, ChallengeCode="urlhere"};
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCodeChallenge(CodeChallenge cc)
        {
            throw new System.NotImplementedException();
        }
    }
}