public interface ILessonAttendanceService
{
    List<LessonAttendance> GetByStudentId(int studentId);
    void IncreaseAbsence(int studentId, string lessonName);
}
