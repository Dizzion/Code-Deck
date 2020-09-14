namespace CodeDeckAPI.Models
{
    public class UserCard
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int CodeCardId { get; set; }
        public CodeCard CodeCard { get; set; }
    }
}