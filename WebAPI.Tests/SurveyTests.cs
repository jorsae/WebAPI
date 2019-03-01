using Library.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Tests
{
    [TestFixture]
    public class SurveyTests
    {
        private Survey survey;

        [SetUp]
        public void SetupBeforeEachTest()
        {
            survey = new Survey(1);
        }

        [Test]
        public void Assert_survey_not_same_id()
        {
            Survey survey2 = new Survey(1);

            Assert.AreNotEqual(survey.Id, survey2.Id);
        }
    }
}
