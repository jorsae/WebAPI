using Library.DataAccess;
using Library.Model;
using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebAPI.Controllers
{
    public class SurveyQuestionController : ApiController
    {
        private LibraryContext db = new LibraryContext();
        /*

        // GET: api/Survey
        public IQueryable<SurveyQuestion> GetSurveyQuestions()
        {
            return db.SurveyQuestions;
        }

        // GET: api/Survey/5
        [Route("api/SurveyQuestion/{id}")]
        [HttpGet]
        [ResponseType(typeof(Survey))]
        public async Task<IHttpActionResult> GetRegisterUser(int id)
        {
            SurveyQuestion surveyQuestion = await db.SurveyQuestions.FindAsync(id);
            return Ok(surveyQuestion);
        }*/
    }
}
