using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class SurveyAnswer
    {
        [Key]
        private int surveyAnswerId;
        public int SurveyAnswerId { get => surveyAnswerId; set => surveyAnswerId = value; }

        public int Answer { get; set; }
        public int SurveyQuestionId { get; set; }
        public SurveyQuestion SurveyQuestion { get; set; }

        // Empty constructor for EntityFramework
        public SurveyAnswer()
        {

        }

        public SurveyAnswer(int answer, int surveyQuestionId)
        {
            Answer = answer;
            SurveyQuestionId = surveyQuestionId;
        }
    }
}