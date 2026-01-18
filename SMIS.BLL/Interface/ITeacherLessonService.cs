using System;
using System.Collections.Generic;
using System.Text;
using SMIS.Entities.Models;

namespace SMIS.BLL.Interface
{
    public interface ITeacherLessonService
    {
        void Assign(int teacherId, string lesson, string className);
        List<TeacherLesson> GetAll();
    }
}
