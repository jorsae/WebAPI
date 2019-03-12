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
using System.Web.Http.Results;

namespace WebAPI.Controllers
{
    public class SurveyController : ApiController
    {
        private LibraryContext db = new LibraryContext();

        // GET: api/Survey
        public IQueryable<Survey> GetSurveys()d
        {
            return db.Surveys;
        }

        // GET: api/Survey/5
        [Route("api/survey/{id}")]
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

            return await SaveDatabaseAsync(survey.SurveyId);
        }

        // DELETE: api/survey/{survey}
        [Route("api/survey/{id}")]
        [HttpDelete]
        [ResponseType(typeof(Survey))]
        public async Task<IHttpActionResult> DeleteSurvey(int id)
        {
            Survey survey = await db.Surveys.FindAsync(id);
            if(survey == null)
            {
                return NotFound();
            }

            db.Surveys.Remove(survey);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }

            return Ok(survey);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }

        private async Task<StatusCodeResult> SaveDatabaseAsync(int surveyId)
        {
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SurveyExists(surveyId))
                {
                    return StatusCode(HttpStatusCode.NotFound);
                }
                else
                {
                    return StatusCode(HttpStatusCode.InternalServerError);
                }
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        private bool SurveyExists(int id)
        {
            return db.Surveys.Count(survey => survey.SurveyId == id) > 0;
        }
    }
}