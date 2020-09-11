using System.ComponentModel.DataAnnotations;

namespace CodeDeckAPI.Models
{
    public class CodeCard
    {
        [Key]
        public int CardId { get; set; }

        [Required]
        public string Challenge { get; set; }
        public Difficulty Difficulty { get; set; } = Difficulty.Easy;
        public string JavaAnswer { get; set; } = null;
        public string JavaScriptAnswer { get; set; } = null;
        public string PythonAnswer { get; set; } = null;
        public string CAnswers { get; set; } = null;
    }
}