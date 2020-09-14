using System.Collections.Generic;

namespace CodeDeckAPI.Models
{
    public class User
    {
        
        public int UserId { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Role { get; set; } = "User";
        public List<UserCard> UserCards { get; set; }
    }
}