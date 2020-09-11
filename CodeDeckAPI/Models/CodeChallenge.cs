using System.ComponentModel.DataAnnotations;

namespace CodeDeckAPI.Models
{
    public class CodeChallenge
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ChallengeCode { get; set; }

        [Required]
        public Difficulty Difficulty { get; set; } = Difficulty.Easy;

        [Required]
        public Answers Answers { get; set; }
    }
}