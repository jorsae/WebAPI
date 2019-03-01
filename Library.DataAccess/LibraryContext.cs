using Library.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess
{
    public class LibraryContext : DbContext
    {
        public virtual DbSet<Survey> Surveys { get; set; }
        public LibraryContext()
        {
            Configuration.ProxyCreationEnabled = false;
            string connectionString = "Server = tcp:bachelorsurvey.database.windows.net,1433; Initial Catalog = BachelorDB; Persist Security Info = False; User ID = bo19funky; Password = 1elvroijwnv%!\"rnåu9vnu59+2; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
            Database.Connection.ConnectionString = connectionString;
            Database.SetInitializer(new LibraryDBInitializer());
        }
    }
}