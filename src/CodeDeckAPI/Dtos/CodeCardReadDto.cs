using CodeDeckAPI.Models;

namespace CodeDeckAPI.Dtos
{
    public class CodeCardReadDto
    {
        public int CardId { get; set; }
        public string Challenge { get; set; }
        public string ChallengeTitle { get; set; }
        public Difficulty Difficulty { get; set; } = Difficulty.Easy;
        public string JavaAnswer { get; set; } = null;
        public string JavaScriptAnswer { get; set; } = null;
        public string PythonAnswer { get; set; } = null;
        public string CAnswers { get; set; } = null;
    }
}