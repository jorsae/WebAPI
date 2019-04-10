using Library.Model;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Library.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<Survey> Surveys { get; set; }
        public virtual DbSet<SurveyQuestion> SurveyQuestions { get; set; }
        public virtual DbSet<SurveyAnswer> SurveyAnswers { get; set; }

        public DatabaseContext()
        {
            Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer(new DatabaseInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));

            modelBuilder.Entity<Survey>()
                .HasMany(survey => survey.SurveyQuestions)
                .WithRequired(surveyQuestion => surveyQuestion.Survey)
                .HasForeignKey<int>(surveyQuestion => surveyQuestion.SurveyId);

            modelBuilder.Entity<SurveyQuestion>()
                .HasMany(surveyQuestion => surveyQuestion.SurveyAnswers)
                .WithRequired(surveyAnswer => surveyAnswer.SurveyQuestion)
                .HasForeignKey<int>(surveyAnwer => surveyAnwer.SurveyQuestionId);

            base.OnModelCreating(modelBuilder);
        }
    }
}