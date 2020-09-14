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
        public DbSet<UserCard> UserCards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCard>()
                .HasKey(uc => new { uc.CodeCardId, uc.UserId });
        }
    }
}