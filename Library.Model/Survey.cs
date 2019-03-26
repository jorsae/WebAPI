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
        public int SurveyId { get; set; }

        public string SurveyTitle { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual ICollection<SurveyQuestion> SurveyQuestions { get; set; } = new List<SurveyQuestion>();

        // Empty constructor for EntityFramework
        public Survey()
        {

        }

        public Survey(string surveyTitle)
        {
            SurveyTitle = surveyTitle;
            CreationDate = DateTime.Now;
        }
    }
}