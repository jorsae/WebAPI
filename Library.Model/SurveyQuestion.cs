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
        public int SurveyQuestionId { get => surveyQuestionId; set => surveyQuestionId = value; }

        private string question;
        public string Question { get => question; set => question = value; }

        private int questionNumber;
        public int QuestionNumber { get => questionNumber; set => questionNumber = value; }

        private Survey survey;
        public Survey Survey { get => survey; set => survey = value; }

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
