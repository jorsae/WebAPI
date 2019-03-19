﻿using System;
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

        private int _answer;
        private int _surveyQuestionId;

        public int Answer { get => _answer; set => _answer = value; }
        public int SurveyQuestionId { get => _surveyQuestionId; set => _surveyQuestionId = value; }

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