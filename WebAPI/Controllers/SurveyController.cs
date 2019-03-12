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
        public async Task<IHttpActionResult> GetSurvey(int id)
        {
            Survey survey = await db.Surveys.FindAsync(id);
            return Ok(survey);
        }

        // PUT: api/Survey/{survey}
        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSurvey(Survey survey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Surveys.Add(survey);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SurveyExists(survey.Id))
                    return NotFound();
                else
                    return StatusCode(HttpStatusCode.InternalServerError);
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        private bool SurveyExists(int id)
        {
            return db.Surveys.Count(survey => survey.Id == id) > 0;
        }
    }
}