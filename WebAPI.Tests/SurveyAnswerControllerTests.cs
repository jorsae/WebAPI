﻿using Library.DataAccess;
using Library.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using WebAPI.Controllers;

namespace WebAPI.Tests
{
    [TestFixture]
    class SurveyAnswerControllerTests
    {
        private DatabaseContext context;
        private SurveyAnswerController saController;
        private SurveyQuestionController sqController;
        private SurveyController surveyController;
        private Survey survey;
        private SurveyQuestion surveyQuestion;
        private SurveyAnswer surveyAnswer;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            context = new DatabaseContext();
            context.Database.Connection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WebApi_TestDatabase2;Integrated Security=True;Pooling=False";
            context.Database.CreateIfNotExists();
        }

        [SetUp]
        public async Task SetUp()
        {
            saController = new SurveyAnswerController();
            sqController = new SurveyQuestionController();
            surveyController = new SurveyController();

            survey = new Survey("test survey");
            await surveyController.PutSurvey(survey);
            surveyQuestion = new SurveyQuestion(survey.SurveyId, 1, "test question");
            await sqController.PutSurveyQuestion(surveyQuestion);
            surveyAnswer = new SurveyAnswer(surveyQuestion.SurveyQuestionId, 4);
        }

        [Test]
        public async Task Assert_put_surveyanswer()
        {
            IHttpActionResult result = await saController.PutSurveyAnswer(surveyAnswer);
            Assert.IsInstanceOf(typeof(OkNegotiatedContentResult<SurveyAnswer>), result);
        }
    }
}