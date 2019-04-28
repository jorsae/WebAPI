using Library.Model;
using System.Data.Entity;

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
            Database.Connection.ConnectionString = @"Data Source = tcp:bo19webapidbserver.database.windows.net,1433; Initial Catalog = bo19WebApi_db; User ID = bo19group@bo19webapidbserver; Password = qoingdigngG#sdgji2Dghrome";
            Database.SetInitializer(new DatabaseInitializer());
        }
    }
}