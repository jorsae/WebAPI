using Library.DataAccess;
using Library.Model;
using System;
using System.Collections.Generic;
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
        private DatabaseContext db = new DatabaseContext();

        // GET: api/survey
        public IQueryable<Survey> GetSurveys()
        {
            return db.Surveys;
        }

        // GET: api/survey/5
        /// <summary>
        /// Gets the survey by id
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [Route("api/survey/{id}")]
        [HttpGet]
        [ResponseType(typeof(Survey))]
        public async Task<IHttpActionResult> GetSurveyById(int id)
        {
            Survey survey = await db.Surveys.FindAsync(id);

            if (survey == null)
                return StatusCode(HttpStatusCode.NoContent);

            return Ok(survey);
        }

        // PUT: api/survey/{survey}
        /// <summary>
        /// Puts survey to database
        /// </summary>
        /// <param name="survey">The survey.</param>
        /// <returns></returns>
        [HttpPut]
        [ResponseType(typeof(Survey))]
        public async Task<IHttpActionResult> PutSurvey(Survey survey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400
            }

            db.Surveys.Add(survey);

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

        [HttpPost]
        [ResponseType(typeof(Survey))]
        public async Task<IHttpActionResult> PostSurveyChange(Survey survey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400
            }

            Survey oldSurvey = await db.Surveys.FindAsync(survey.SurveyId);
            oldSurvey.SurveyTitle = survey.SurveyTitle;
            oldSurvey.CreationDate = survey.CreationDate;
            oldSurvey.ClosingDate = survey.ClosingDate;
            db.Entry(oldSurvey).State = EntityState.Modified;
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
            return Ok(oldSurvey);
        }

        // PUT: api/survey/inactive/{surveyId}
        [Route("api/survey/inactive/{surveyId}")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> SurveyInactive(int surveyId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400
            }

            Survey survey = await db.Surveys.FindAsync(surveyId);
            survey.ClosingDate = DateTime.Now;
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
            return StatusCode(HttpStatusCode.Created);
        }

        // DELETE: api/survey/{survey}
        /// <summary>
        /// Deletes survey from database
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
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

            return StatusCode(HttpStatusCode.Created);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// returns true if survey exists. False otherwise.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private bool SurveyExists(int id)
        {
            return db.Surveys.Count(survey => survey.SurveyId == id) > 0;
        }
    }
}