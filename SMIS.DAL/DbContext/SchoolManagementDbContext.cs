using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SMIS.Entities.Models;


namespace SMIS.DAL.Context
{
    public class SchoolManagementDbContext : DbContext
    {
        public SchoolManagementDbContext(DbContextOptions<SchoolManagementDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<LessonSchedule> LessonSchedules { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<TeacherLesson> TeacherLessons { get; set; }
        public DbSet<ParentStudent> ParentStudents { get; set; }
        public DbSet<LessonAttendance> LessonAttendances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParentStudent>()
                .HasOne(x => x.Parent)
                .WithMany()
                .HasForeignKey(x => x.ParentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ParentStudent>()
                .HasOne(x => x.Student)
                .WithMany()
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
