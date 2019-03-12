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
    public class SurveyQuestionController : ApiController
    {
        private LibraryContext db = new LibraryContext();

        // GET: api/surveyquestion
        public IQueryable<SurveyQuestion> GetSurveyQuestions()
        {
            return db.SurveyQuestions;
        }

        // GET: api/surveyquestion/5
        [Route("api/surveyquestion/{id}")]
        [HttpGet]
        [ResponseType(typeof(SurveyQuestion))]
        public async Task<IHttpActionResult> GetRegisterUser(int id)
        {
            SurveyQuestion surveyQuestion = await db.SurveyQuestions.FindAsync(id);
            return Ok(surveyQuestion);
        }

        // PUT: api/surveyquestion/{surveyquestion}
        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSurveyQuestion(SurveyQuestion surveyQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SurveyQuestions.Add(surveyQuestion);

            return await SaveDatabaseAsync(surveyQuestion.SurveyQuestionId);
        }

        // DELETE: api/surveyquestion/{surveyquestion}
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

            return Ok(surveyQuestion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }

        private async Task<StatusCodeResult> SaveDatabaseAsync(int surveyQuestionId)
        {
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SurveyQuestionExists(surveyQuestionId))
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

        // testkommentar
        private bool SurveyQuestionExists(int id)
        {
            return db.SurveyQuestions.Count(surveyQuestion => surveyQuestion.SurveyQuestionId == id) > 0;
        }
    }
}
