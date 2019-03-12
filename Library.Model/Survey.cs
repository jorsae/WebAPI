using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Survey
    {
        [Key]
        private int surveyId;
        public int SurveyId { get => surveyId; set => surveyId = value; }

        private int userId;
        public int UserId { get => userId; set => userId = value; }

        private DateTime creationDate;
        public DateTime CreationDate { get => creationDate; set => creationDate = value; }

        public virtual ICollection<SurveyQuestion> SurveyQuestions { get; set; } = new List<SurveyQuestion>();

        private static int NumberOfSurveys = 0;

        // Empty constructor for EntityFramework
        public Survey()
        {

        }

        public Survey(int userId)
        {
            SurveyId = NumberOfSurveys++;
            UserId = userId;
            CreationDate = DateTime.Now;
        }
    }
}