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
        private DatabaseContext db = new DatabaseContext();

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
        [ResponseType(typeof(SurveyQuestion))]
        public async Task<IHttpActionResult> PutSurveyQuestion(SurveyQuestion surveyQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int questionNumber = db.SurveyQuestions
                                .Where(sq => sq.SurveyId == surveyQuestion.SurveyId)
                                .Select(sq => sq.QuestionNumber)
                                .DefaultIfEmpty(1)
                                .Max();

            surveyQuestion.QuestionNumber = questionNumber;
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

            return Ok(surveyQuestion);
        }

        // DELETE: api/surveyquestion/{surveyquestion}
        /// <summary>
        /// Deletes the SurveyQuestion from database
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [Route("api/surveyquestion/{surveyQuestionId}")]
        [HttpDelete]
        [ResponseType(typeof(SurveyQuestion))]
        public async Task<IHttpActionResult> DeleteSurveyQuestion(int surveyQuestionId)
        {
            SurveyQuestion surveyQuestion = await db.SurveyQuestions.FindAsync(surveyQuestionId);
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

        [Route("api/surveyquestion/stats/{surveyQuestionId}")]
        [HttpGet]
        [ResponseType(typeof(float))]
        public IHttpActionResult GetSurveyQuestionStats(int surveyQuestionId)
        {
            var stats = db.SurveyAnswers.Where(i => i.SurveyQuestionId == surveyQuestionId)
                .GroupBy(g => g.SurveyQuestionId)
                .Select(g => new
                {
                    Count = g.Count(),
                    Max = g.Max(i => i.Answer),
                    Min = g.Min(i => i.Answer),
                    Average = g.Average(i => i.Answer)
                }).First();
            return Ok(stats);
        }

        [Route("api/surveyquestion/frequency/{surveyQuestionId}")]
        [HttpGet]
        [ResponseType(typeof(float))]
        public IHttpActionResult GetSurveyQuestionFrequency(int surveyQuestionId)
        {
            IEnumerable<int> mostFrequent = db.SurveyAnswers
                       .Where(a => a.SurveyQuestionId == surveyQuestionId)
                       .GroupBy(i => i.Answer)
                       .OrderByDescending(g => g.Count())
                       .Take(10)
                       .Select(g => g.Key);
            return Ok(mostFrequent);
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
