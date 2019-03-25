using Library.Model;
using System.Data.Entity;

namespace Library.DataAccess
{
    public class LibraryDBInitializer : DropCreateDatabaseIfModelChanges<LibraryContext>
    {
        protected override void Seed(LibraryContext context)
        {
            Survey survey1 = new Survey(1, "Arbeidsplass");
            SurveyQuestion surveyQuestion1 = new SurveyQuestion(1, "Liker du arbeidsplassen din?");
            SurveyAnswer survey1Answer1 = new SurveyAnswer(3, surveyQuestion1.SurveyQuestionId);
            SurveyAnswer survey1Answer2 = new SurveyAnswer(5, surveyQuestion1.SurveyQuestionId);

            Survey survey2 = new Survey(2, "Mat Survey");
            SurveyQuestion surveyQuestion2 = new SurveyQuestion(1, "Liker du pannekaker??");
            SurveyAnswer survey2Answer1 = new SurveyAnswer(3, surveyQuestion2.SurveyQuestionId);
            SurveyAnswer survey2Answer2 = new SurveyAnswer(7, surveyQuestion2.SurveyQuestionId);

            SurveyQuestion surveyQuestion3 = new SurveyQuestion(2, "Liker du vaffler?");
            SurveyAnswer survey2Answer3 = new SurveyAnswer(6, surveyQuestion3.SurveyQuestionId);
            SurveyAnswer survey2Answer4 = new SurveyAnswer(10, surveyQuestion3.SurveyQuestionId);
            SurveyAnswer survey2Answer5 = new SurveyAnswer(9, surveyQuestion3.SurveyQuestionId);

            survey1.SurveyQuestions.Add(surveyQuestion1);
            surveyQuestion1.SurveyAnswers.Add(survey1Answer1);
            surveyQuestion1.SurveyAnswers.Add(survey1Answer2);

            survey2.SurveyQuestions.Add(surveyQuestion2);
            survey2.SurveyQuestions.Add(surveyQuestion3);

            surveyQuestion2.SurveyAnswers.Add(survey2Answer1);
            surveyQuestion2.SurveyAnswers.Add(survey2Answer2);

            surveyQuestion3.SurveyAnswers.Add(survey2Answer3);
            surveyQuestion3.SurveyAnswers.Add(survey2Answer4);
            surveyQuestion3.SurveyAnswers.Add(survey2Answer5);

            context.Surveys.Add(survey1);
            context.Surveys.Add(survey2);

            context.SurveyQuestions.Add(surveyQuestion1);
            context.SurveyQuestions.Add(surveyQuestion2);

            context.SurveyAnswers.Add(survey1Answer1);
            context.SurveyAnswers.Add(survey1Answer2);
            context.SurveyAnswers.Add(survey2Answer3);
            context.SurveyAnswers.Add(survey2Answer4);
            context.SurveyAnswers.Add(survey2Answer5);

            base.Seed(context);
        }
    }
}