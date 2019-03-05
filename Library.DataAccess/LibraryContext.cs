using Library.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess
{
    public class LibraryContext : DbContext
    {
        public virtual DbSet<Survey> Surveys { get; set; }
        public virtual DbSet<SurveyQuestion> SurveyQuestions { get; set; }
        public virtual DbSet<SurveyAnswer> SurveyAnswers { get; set; }

        public LibraryContext()
        {
            Configuration.ProxyCreationEnabled = false;
            string connectionString = "Server = tcp:bachelorsurvey.database.windows.net,1433; Initial Catalog = BachelorDB; Persist Security Info = False; User ID = bo19funky; Password = 1elvroijwnv%!\"rnåu9vnu59+2; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
            Database.Connection.ConnectionString = connectionString;
            Database.SetInitializer(new LibraryDBInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));

            modelBuilder.Entity<Survey>()
                .HasMany(survey => survey.SurveyQuestions)
                .WithMany(surveyQuestion => surveyQuestion.Surveys)
                .Map(m =>
                {
                    m.ToTable("Survey_SurveyQuestion");
                    m.MapLeftKey("SurveyId");
                    m.MapRightKey("SurveyQuestionId");
                });

            modelBuilder.Entity<SurveyQuestion>()
                .HasMany(surveyQuestion => surveyQuestion.SurveyAnswers)
                .WithMany(surveyAnswer => surveyAnswer.SurveyQuestions)
                .Map(m =>
                {
                    m.ToTable("SurveyQuestion_SurveyAnswer");
                    m.MapLeftKey("SurveyQuestionId");
                    m.MapRightKey("SurveyAnswerId");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}