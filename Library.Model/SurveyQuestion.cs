using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Library.Model
{
    public class SurveyQuestion
    {
        [Key]
        public int SurveyQuestionId { get; set; }
        [Required]
        [MaxLength(255)]
        public string Question { get; set; }
        [Required]
        [Range(1, 3)]
        public int QuestionNumber { get; set; }
        [Required]
        public int SurveyId { get; set; }
        public Survey Survey { get; set; }

        [IgnoreDataMember]
        public virtual List<SurveyAnswer> SurveyAnswers { get; set; } = new List<SurveyAnswer>();

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