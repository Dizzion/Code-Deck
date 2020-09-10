namespace CodeDeckAPI.Models
{
    public class PythonAnswers
    {
        public int Id { get; set; }
        public string AnswerCode { get; set; }
        public Answers Answers { get; set; }
        public int AnswersId { get; set; }
    }
}