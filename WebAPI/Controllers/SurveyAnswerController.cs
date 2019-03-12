using Library.DataAccess;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebAPI.Controllers
{
    public class SurveyAnswerController : ApiController
    {
        private LibraryContext db = new LibraryContext();

        // GET: api/SurveyAnswer
        public IQueryable<SurveyAnswer> GetSurveyAnswers()
        {
            return db.SurveyAnswers;
        }

        // GET: api/Survey/5
        [Route("api/SurveyAnswer/{id}")]
        [HttpGet]
        [ResponseType(typeof(Survey))]
        public async Task<IHttpActionResult> GetSurveyQuestions(int id)
        {
            SurveyAnswer surveyAnswer = await db.SurveyAnswers.FindAsync(id);
            return Ok(surveyAnswer);
        }
    }
}