using Library.DataAccess;
using Library.Model;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using System.Transactions;
using System.Web.Http;
using System.Web.Http.Results;
using WebAPI.Controllers;

namespace WebAPI.Tests
{
    [TestFixture]
    public class SurveyControllerTests
    {
        private DatabaseContext context;
        private SurveyController surveyController;
        private Survey survey;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            context = new DatabaseContext();
            context.Database.Connection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WebApi_TestDatabase2;Integrated Security=True;Pooling=False";
            context.Database.CreateIfNotExists();
        }

        [SetUp]
        public void SetupBeforeEachTest()
        {
            survey = new Survey("Test");
            surveyController = new SurveyController();
        }

        [Test]
        public async Task Assert_put_survey()
        {
            IHttpActionResult actionResult = await surveyController.PutSurvey(survey);
            var contentResult = actionResult as OkNegotiatedContentResult<Survey>;
            Assert.IsNotNull(contentResult);
        }

        [Test]
        public async Task Assert_get_survey_by_id()
        {
            IHttpActionResult actionResult = await surveyController.PutSurvey(survey);
            var contentResult = actionResult as OkNegotiatedContentResult<Survey>;
            Assert.IsNotNull(contentResult);

            IHttpActionResult result = await surveyController.GetSurveyById(survey.SurveyId);
            var getContentResult = actionResult as OkNegotiatedContentResult<Survey>;
            Assert.NotNull(getContentResult);
        }
    }
}
