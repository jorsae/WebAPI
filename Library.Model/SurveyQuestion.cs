using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class SurveyQuestion
    {
        [Key]
        private int surveyQuestionId;
        public int SurveyQuestionId
        {
            get { return surveyQuestionId; }
            set
            {
                surveyQuestionId = value;
            }
        }

        private string _question;
        public string Question { get => _question; set => _question = value; }

        public int QuestionNumber { get; set; }
        public int SurveyId { get; set; }
        public Survey Survey { get; set; }

        public virtual List<SurveyAnswer> SurveyAnswers { get; set; } = new List<SurveyAnswer>();

        private static int NumberOfSurveyQuestions = 0;

        // Empty constructor for EntityFramework
        public SurveyQuestion()
        {

        }

        public SurveyQuestion(int questionNumber, string question)
        {
            surveyQuestionId = NumberOfSurveyQuestions++;
            QuestionNumber = questionNumber;
            Question = question;
        }
    }
}
