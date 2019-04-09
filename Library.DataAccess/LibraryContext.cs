﻿using Library.Model;
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
            Database.Connection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WebApi_TestDatabase;Integrated Security=True;Pooling=False";
            Database.CreateIfNotExists();
            Database.SetInitializer(new LibraryDBInitializer());
        }
    }
}