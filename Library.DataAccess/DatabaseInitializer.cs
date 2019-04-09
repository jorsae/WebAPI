using Library.Model;
using System.Data.Entity;

namespace Library.DataAccess
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            Survey survey1 = new Survey("Arbeidsplass");
            SurveyQuestion surveyQuestion1 = new SurveyQuestion(survey1.SurveyId, 1, "Liker du arbeidsplassen din?");
            surveyQuestion1.Survey = survey1;
            SurveyAnswer survey1Answer1 = new SurveyAnswer(surveyQuestion1.SurveyQuestionId, 3);
            survey1Answer1.SurveyQuestion = surveyQuestion1;
            SurveyAnswer survey1Answer2 = new SurveyAnswer(surveyQuestion1.SurveyQuestionId, 5);
            survey1Answer2.SurveyQuestion = surveyQuestion1;

            Survey survey2 = new Survey("Mat Survey");
            SurveyQuestion surveyQuestion2 = new SurveyQuestion(survey2.SurveyId, 1, "Liker du pannekaker??");
            surveyQuestion2.Survey = survey2;
            SurveyAnswer survey2Answer1 = new SurveyAnswer(surveyQuestion2.SurveyQuestionId, 3);
            survey2Answer1.SurveyQuestion = surveyQuestion2;
            SurveyAnswer survey2Answer2 = new SurveyAnswer(surveyQuestion2.SurveyQuestionId, 7);
            survey2Answer2.SurveyQuestion = surveyQuestion2;

            SurveyQuestion surveyQuestion3 = new SurveyQuestion(survey2.SurveyId, 2, "Liker du vaffler?");
            surveyQuestion3.Survey = survey2;
            SurveyAnswer survey3Answer1 = new SurveyAnswer(surveyQuestion3.SurveyQuestionId, 6);
            survey3Answer1.SurveyQuestion = surveyQuestion2;
            SurveyAnswer survey3Answer2 = new SurveyAnswer(surveyQuestion3.SurveyQuestionId, 10);
            survey3Answer2.SurveyQuestion = surveyQuestion2;
            SurveyAnswer survey3Answer3 = new SurveyAnswer(surveyQuestion3.SurveyQuestionId, 9);
            survey3Answer3.SurveyQuestion = surveyQuestion2;

            context.Surveys.Add(survey1);

            context.SurveyQuestions.Add(surveyQuestion1);
            context.SurveyAnswers.Add(survey1Answer1);
            context.SurveyAnswers.Add(survey1Answer2);

            context.Surveys.Add(survey2);

            context.SurveyQuestions.Add(surveyQuestion2);
            context.SurveyAnswers.Add(survey2Answer1);
            context.SurveyAnswers.Add(survey2Answer2);

            context.SurveyQuestions.Add(surveyQuestion3);
            context.SurveyAnswers.Add(survey3Answer1);
            context.SurveyAnswers.Add(survey3Answer2);
            context.SurveyAnswers.Add(survey3Answer3);

            base.Seed(context);
        }
    }
}