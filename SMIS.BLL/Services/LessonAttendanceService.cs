using SMIS.DAL.Context;

public class LessonAttendanceService : ILessonAttendanceService
{
    private readonly SchoolManagementDbContext _context;

    public LessonAttendanceService(SchoolManagementDbContext context)
    {
        _context = context;
    }

    public List<LessonAttendance> GetByStudentId(int studentId)
    {
        return _context.LessonAttendances
            .Where(x => x.StudentId == studentId)
            .ToList();
    }

    public void IncreaseAbsence(int studentId, string lessonName)
    {
        var record = _context.LessonAttendances
            .FirstOrDefault(x => x.StudentId == studentId && x.LessonName == lessonName);

        if (record == null)
        {
            record = new LessonAttendance
            {
                StudentId = studentId,
                LessonName = lessonName,
                AbsenceCount = 1
            };
            _context.LessonAttendances.Add(record);
        }
        else
        {
            record.AbsenceCount++;
        }

        _context.SaveChanges();
    }
}
