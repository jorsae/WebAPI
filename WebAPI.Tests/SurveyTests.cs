using Library.DataAccess;
using Library.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Tests
{
    [TestFixture]
    public class SurveyTests
    {
        private LibraryContext db;
        private Survey survey;

        [SetUp]
        public void SetupBeforeEachTest()
        {
            db = new LibraryContext();
            survey = new Survey("test survey");
        }

        [Test]
        public void Assert_ClosingDate_is_default_7days_after_creation()
        {
            DateTime newDate = survey.CreationDate.AddDays(7);
            Assert.True(newDate.Equals(survey.ClosingDate));
        }
    }
}
