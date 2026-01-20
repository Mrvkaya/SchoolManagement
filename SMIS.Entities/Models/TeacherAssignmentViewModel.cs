using SMIS.Entities.Models;
using System.Collections.Generic;

namespace SMIS.UI.Models
{
    public class TeacherAssignmentViewModel
    {
        public List<User> Teachers { get; set; }
        public List<TeacherLesson> Assignments { get; set; }
    }
}
