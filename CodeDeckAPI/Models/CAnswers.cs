namespace CodeDeckAPI.Models
{
    public class CAnswers
    {
        public int Id { get; set; }
        public string AnswerCode { get; set; }
        public Answers Answers { get; set; }
        public int ANswersId { get; set; }
    }
}