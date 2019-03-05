using Library.Model;
using System.Data.Entity;

namespace Library.DataAccess
{
    public class LibraryDBInitializer : DropCreateDatabaseIfModelChanges<LibraryContext>
    {
        protected override void Seed(LibraryContext context)
        {
            Survey survey = new Survey(1);
            SurveyQuestion surveyQuestion = new SurveyQuestion(1, "Liker du arbeidsplassen din?");
            SurveyAnswer surveyAnswer = new SurveyAnswer(1, 3);
            SurveyAnswer surveyAnswer2 = new SurveyAnswer(1, 5);

            survey.SurveyQuestions.Add(surveyQuestion);
            surveyQuestion.SurveyAnswers.Add(surveyAnswer);
            surveyQuestion.SurveyAnswers.Add(surveyAnswer2);

            context.Surveys.Add(survey);
            context.SurveyQuestions.Add(surveyQuestion);
            context.SurveyAnswers.Add(surveyAnswer);

            base.Seed(context);
        }
    }
}