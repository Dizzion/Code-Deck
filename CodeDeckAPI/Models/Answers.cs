using System.ComponentModel.DataAnnotations;

namespace CodeDeckAPI.Models
{
    public class Answers
    {
        [Key]
        public int Id { get; set; }
        public CodeChallenge CodeChallenge { get; set; }
        public int CodeChallengeId { get; set; }
        public JavaScriptAnswers JavaScriptAnswers { get; set; }

    }
}