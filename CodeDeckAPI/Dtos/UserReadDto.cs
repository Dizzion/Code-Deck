using System.Collections.Generic;
using CodeDeckAPI.Models;

namespace CodeDeckAPI.Dtos
{
    public class UserReadDto
    {
        public string Username { get; set; }
        public string Role { get; set; }
        public List<UserCard> UserCards { get; set; }
    }
}