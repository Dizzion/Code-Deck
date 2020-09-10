using CodeDeckAPI.Models;

namespace CodeDeckAPI.Dtos
{
    public class CodeChallengeReadDto
    {
        public int Id { get; set; }
        public string ChallengeCode { get; set; }
        public Difficulty Difficulty { get; set; }
    }
}