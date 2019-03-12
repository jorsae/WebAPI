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
    public class SurveyController : ApiController
    {
        private LibraryContext db = new LibraryContext();
        // GET: api/Survey
        public IQueryable<Survey> GetSurveys()
        {
            return db.Surveys;
        }

        // GET: api/Survey/5
        [Route("api/Survey/{id}")]
        [HttpGet]
        [ResponseType(typeof(Survey))]
        public async Task<IHttpActionResult> GetRegisterUser(int id)
        {
            Survey survey = await db.Surveys.FindAsync(id);
            return Ok(survey);
        }
    }
}