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
            Database.Connection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WebApi_TestDatabase2;Integrated Security=True;Pooling=False";
            Database.SetInitializer(new DatabaseInitializer());
        }
    }
}