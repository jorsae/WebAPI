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
        public int SurveyAnswerId { get; set; }
        public int Answer { get; set; }
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