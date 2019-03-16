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
    public class SurveyQuestionController : ApiController
    {
        private LibraryContext db = new LibraryContext();

        // GET: api/surveyquestion
        public IQueryable<SurveyQuestion> GetSurveyQuestions()
        {
            return db.SurveyQuestions;
        }

        // GET: api/surveyquestion/5
        /// <summary>
        /// Gets the SurveyQuestion based on id
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [Route("api/surveyquestion/{id}")]
        [HttpGet]
        [ResponseType(typeof(SurveyQuestion))]
        public async Task<IHttpActionResult> GetSurveyQuestion(int id)
        {
            SurveyQuestion surveyQuestion = await db.SurveyQuestions.FindAsync(id);
            if (surveyQuestion == null)
                return StatusCode(HttpStatusCode.NoContent);

            return Ok(surveyQuestion);
        }

        [Route("api/surveyquestion/surveyid/{surveyId}")]
        [HttpGet]
        [ResponseType(typeof(SurveyQuestion))]
        public async Task<IHttpActionResult> GetSurveyQuestionBySurveyId(int surveyId)
        {
            List<SurveyQuestion> surveyQuestions = await (from surveyQuestion in db.SurveyQuestions
                                                    where surveyQuestion.SurveyId == surveyId
                                                    select surveyQuestion).ToListAsync();
            if (surveyQuestions.Count <= 0)
                return StatusCode(HttpStatusCode.NoContent);

            return Ok(surveyQuestions);
        }

        // PUT: api/surveyquestion/{surveyquestion}
        /// <summary>
        /// Puts the survey question in database
        /// </summary>
        /// <param name="surveyQuestion">The survey question.</param>
        /// <returns></returns>
        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSurveyQuestion(SurveyQuestion surveyQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SurveyQuestions.Add(surveyQuestion);

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

        // DELETE: api/surveyquestion/{surveyquestion}
        /// <summary>
        /// Deletes the SurveyQuestion from database
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [Route("api/surveyquestion/{id}")]
        [HttpDelete]
        [ResponseType(typeof(SurveyQuestion))]
        public async Task<IHttpActionResult> DeleteSurveyQuestion(int id)
        {
            SurveyQuestion surveyQuestion = await db.SurveyQuestions.FindAsync(id);
            if (surveyQuestion == null)
            {
                return NotFound();
            }

            db.SurveyQuestions.Remove(surveyQuestion);

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

        private bool SurveyQuestionExists(int id)
        {
            return db.SurveyQuestions.Count(surveyQuestion => surveyQuestion.SurveyQuestionId == id) > 0;
        }
    }
}
