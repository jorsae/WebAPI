using Library.DataAccess;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;

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
        /// <summary>
        /// Gets the survey answer based on id
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [Route("api/surveyanswer/{id}")]
        [HttpGet]
        [ResponseType(typeof(SurveyAnswer))]
        public async Task<IHttpActionResult> GetSurveyAnswer(int id)
        {
            SurveyAnswer surveyAnswer = await db.SurveyAnswers.FindAsync(id);
            return Ok(surveyAnswer);
        }

        // PUT: api/Survey/{survey}
        /// <summary>
        /// Puts the SurveyAnswer in database
        /// </summary>
        /// <param name="surveyAnswer">The survey answer.</param>
        /// <returns></returns>
        [HttpPut]
        [ResponseType(typeof(SurveyAnswer))]
        public async Task<IHttpActionResult> PutSurveyAnswer(SurveyAnswer surveyAnswer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SurveyAnswers.Add(surveyAnswer);

            return await SaveDatabaseAsync(surveyAnswer.SurveyAnswerId);
        }

        private async Task<IHttpActionResult> SaveDatabaseAsync(int surveyAnswerId)
        {
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SurveyAnswerExists(surveyAnswerId))
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

        private bool SurveyAnswerExists(int id)
        {
            return db.SurveyAnswers.Count(surveyAnswer => surveyAnswer.SurveyAnswerId == id) > 0;
        }
    }
}