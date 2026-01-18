using System;
using System.Collections.Generic;
using System.Text;

namespace SMIS.Entities.Models
{
    public class TeacherLesson
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public string LessonName { get; set; }
        public string ClassName { get; set; }
    }
}
