using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Survey
    {
        private int id;
        public int Id { get => id; set => id = value; }

        private int userId;
        public int UserId { get => userId; set => userId = value; }

        private DateTime creationTime;
        public DateTime CreationTime { get => creationTime; set => creationTime = value; }


        private static int NumberOfSurveys = 0;

        public Survey(int userId)
        {
            Id = NumberOfSurveys++;
            UserId = userId;
            CreationTime = DateTime.Now;
        }
    }
}