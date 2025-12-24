using System;
using System.Collections.Generic;
using System.Text;

namespace SMIS.Entities.Models
{
    public class Grade
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public User Student { get; set; }

        public string LessonName { get; set; }
        public int Score { get; set; }
    }
}
