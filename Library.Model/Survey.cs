using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Survey
    {
        private int id;
        public int Id { get => id; set => id = value; }

        private int userId;
        public int UserId { get => userId; set => userId = value; }

        private DateTime creationDate;
        public DateTime CreationDate { get => creationDate; set => creationDate = value; }

        public virtual List<SurveyQuestion> SurveyQuestions { get; set; } = new List<SurveyQuestion>();

        private static int NumberOfSurveys = 0;

        // Empty constructor for EntityFramework
        public Survey()
        {

        }

        public Survey(int userId)
        {
            Id = NumberOfSurveys++;
            UserId = userId;
            CreationDate = DateTime.Now;
        }
    }
}