using Library.DataAccess;
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
    class SurveyQuestionControllerTests
    {
        private DatabaseContext context;
        private SurveyQuestionController sqController;
        private SurveyQuestion surveyQuestion;
        private Survey survey;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            context = new DatabaseContext();
            context.Database.Connection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WebApi_TestDatabase2;Integrated Security=True;Pooling=False";
            context.Database.CreateIfNotExists();

            survey = new Survey("test survey");
            SurveyController surveyController = new SurveyController();
            await surveyController.PutSurvey(survey);
        }

        [SetUp]
        public void SetUp()
        {
            surveyQuestion = new SurveyQuestion(survey.SurveyId, 1, "test question");
            sqController = new SurveyQuestionController();
        }

        [Test]
        public async Task Assert_put_surveyquestion()
        {
            IHttpActionResult result = await sqController.PutSurveyQuestion(surveyQuestion);
            Assert.IsInstanceOf(typeof(OkNegotiatedContentResult<SurveyQuestion>), result);
        }

        [Test]
        public async Task Assert_fail_put_surveyquestion_wrong_surveyid()
        {
            IHttpActionResult result = await sqController.PutSurveyQuestion(new SurveyQuestion(1000, 1, "question"));
            Assert.IsNotInstanceOf(typeof(OkNegotiatedContentResult<SurveyQuestion>), result);
        }
    }
}
