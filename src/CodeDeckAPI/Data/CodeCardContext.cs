using CodeDeckAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeDeckAPI.Data
{
    public class CodeCardContext :DbContext
    {
        public CodeCardContext(DbContextOptions<CodeCardContext> opt) : base(opt)
        {

        }

        public DbSet<CodeCard> CodeCards { get; set; }
        public DbSet<User> Users { get; set; }
    }
}