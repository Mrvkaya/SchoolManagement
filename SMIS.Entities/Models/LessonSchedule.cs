using System;
using System.Collections.Generic;
using System.Text;

namespace SMIS.Entities.Models
{
    public class LessonSchedule
    {
        public int Id { get; set; }
        public string LessonName { get; set; }
        public string Day { get; set; }
        public TimeOnly Hour { get; set; }
    }
}
