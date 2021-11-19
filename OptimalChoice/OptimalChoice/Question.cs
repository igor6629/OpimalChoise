using System.Collections.Generic;

namespace OptimalChoice_
{
    public class Question
    {
        public Question(string questionStr, List<string> answers)
        {
            this.QuestionStr = questionStr;
            this.Answers = new List<string>(answers);
        }

        public List<string> Answers { get; set; }
        public string QuestionStr { get; set; }
    }
}