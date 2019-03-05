using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class SurveyQuestion
    {
        private int surveyQuestionId;
        public int SurveyQuestionId { get => surveyQuestionId; set => surveyQuestionId = value; }

        private string question;
        public string Question { get => question; set => question = value; }

        public List<Survey> Surveys { get; set; } = new List<Survey>();
        public virtual List<SurveyAnswer> SurveyAnswers { get; set; } = new List<SurveyAnswer>();

        // Empty constructor for EntityFramework
        public SurveyQuestion()
        {

        }

        public SurveyQuestion(int surveyQuestionId, string question)
        {
            SurveyQuestionId = surveyQuestionId;
            Question = question;
        }
    }
}
