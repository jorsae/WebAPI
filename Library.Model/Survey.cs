using System;
using System.Collections.Generic;

namespace Library.Model
{
    public class Survey
    {
        public int SurveyId { get; set; }

        public string SurveyTitle { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ClosingDate { get; set; }

        // Empty constructor for EntityFramework
        public Survey()
        {

        }

        public Survey(string surveyTitle, DateTime? closingDate = null)
        {
            CreationDate = DateTime.Now;
            SurveyTitle = surveyTitle;
            ClosingDate = (closingDate == null) ? CreationDate.AddDays(7) : (DateTime)closingDate;
        }

        public bool IsActive()
        {
            if (ClosingDate >= DateTime.Now)
                return true;
            else
                return false;
        }
    }
}