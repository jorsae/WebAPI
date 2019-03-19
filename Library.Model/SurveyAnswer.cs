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
        private int _answer;
        private int _surveyQuestionId;
        private int _surveyAnswerId;
        private SurveyQuestion _surveyQuestion;

        [Key]
        public int SurveyAnswerId { get => _surveyAnswerId; set => _surveyAnswerId = value; }
        public int Answer { get => _answer; set => _answer = value; }
        public int SurveyQuestionId { get => _surveyQuestionId; set => _surveyQuestionId = value; }

        public SurveyQuestion SurveyQuestion { get => _surveyQuestion; set => _surveyQuestion = value; }

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