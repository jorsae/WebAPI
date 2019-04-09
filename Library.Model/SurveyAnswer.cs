using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Model
{
    public class SurveyAnswer
    {
        public int SurveyAnswerId { get; set; }
        public int Answer { get; set; }

        [ForeignKey("SurveyQuestion")]
        public int SurveyQuestionId { get; set; }
        public SurveyQuestion SurveyQuestion { get; set; }

        // Empty constructor for EntityFramework
        public SurveyAnswer()
        {

        }

        public SurveyAnswer(int surveyQuestionId, int answer)
        {
            SurveyQuestionId = surveyQuestionId;
            Answer = answer;
        }
    }
}