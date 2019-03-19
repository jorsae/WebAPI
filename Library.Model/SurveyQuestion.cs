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
        public int SurveyQuestionId { get; set; }

        public string Question { get; set; }
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
            SurveyQuestionId = NumberOfSurveyQuestions++;
            QuestionNumber = questionNumber;
            Question = question;
        }
    }
}
