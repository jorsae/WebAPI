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

        private int answer;
        public int Answer { get => answer; set => answer = value; }

        private int surveyQuestionId;
        public int SurveyQuestionId { get => surveyQuestionId; set => surveyQuestionId = value; }

        private SurveyQuestion surveyQuestion;
        public SurveyQuestion SurveyQuestion { get => surveyQuestion; set => surveyQuestion = value; }

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