using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Model
{
    public class SurveyQuestion
    {
        public int SurveyQuestionId { get; set; }

        public string Question { get; set; }
        public int QuestionNumber { get; set; }
        [ForeignKey("Survey")]
        public int SurveyId { get; set; }
        public Survey Survey { get; set; }

        // Empty constructor for EntityFramework
        public SurveyQuestion()
        {

        }

        public SurveyQuestion(int surveyId, int questionNumber, string question)
        {
            SurveyId = surveyId;
            QuestionNumber = questionNumber;
            Question = question;
        }
    }
}