using System.ComponentModel.DataAnnotations;
using CodeDeckAPI.Models;

namespace CodeDeckAPI.Dtos
{
    public class CodeChallengeCreateDto
    {
        [Required]
        public string ChallengeCode { get; set; }
        public Difficulty Difficulty { get; set; }
    }
}