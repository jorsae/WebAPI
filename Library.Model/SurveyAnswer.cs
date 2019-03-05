using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class SurveyAnswer
    {
        private int surveyAnswerId;

        public int SurveyAnswerId { get => surveyAnswerId; set => surveyAnswerId = value; }

        private int answer;
        public int Answer { get => answer; set => answer = value; }

        public virtual List<SurveyQuestion> SurveyQuestions{ get; set; } = new List<SurveyQuestion>();

        // Empty constructor for EntityFramework
        public SurveyAnswer()
        {

        }
        public SurveyAnswer(int surveyAnswerId, int answer)
        {
            SurveyAnswerId = surveyAnswerId;
            Answer = answer;
        }
    }
}