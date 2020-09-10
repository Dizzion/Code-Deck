using CodeDeckAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeDeckAPI.Data
{
    public class CodeChallengeContext :DbContext
    {
        public CodeChallengeContext(DbContextOptions<CodeChallengeContext> opt) : base(opt)
        {

        }

        public DbSet<CodeChallenge> CodeChallenges { get; set; }
        public DbSet<Answers> Answers { get; set; }
    }
}