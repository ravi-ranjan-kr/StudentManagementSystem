using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;
using System;


namespace StudentManagementRepositoryLayer
{
    public class StudentMngmntDbContext : DbContext
    {
        public StudentMngmntDbContext(DbContextOptions options) : base(options)
        {

        }
        DbSet<Student> Student { get; set; }

        DbSet<StudentMarks> stuMarks { get; set; }
    }
}
