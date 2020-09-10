using System.ComponentModel.DataAnnotations;

namespace CodeDeckAPI.Models
{
    public class JavaScriptAnswers
    {
        [Key]
        public int Id { get; set; }

        public string JavaScriptAnswer { get; set; }
        public Answers Answers { get; set; }
        public int AnswersId { get; set; }
    }
}