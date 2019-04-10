﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class SurveyQuestion
    {
        public int SurveyQuestionId { get; set; }
        [Required]
        [MaxLength(255)]
        public string Question { get; set; }
        [Required]
        [Range(1, 3)]
        public int QuestionNumber { get; set; }
        [ForeignKey("Survey")]
        public int SurveyId { get; set; }
        [IgnoreDataMember]
        public Survey Survey { get; set; }

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