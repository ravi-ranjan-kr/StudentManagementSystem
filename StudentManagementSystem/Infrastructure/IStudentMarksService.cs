using StudentManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagementSystem.Infrastructure
{
    public interface IStudentMarksService
    {
        Task<IList<StudentMarks>> GetStudentMarksList();

        void AddStudentMarks(StudentMarks stuMarks);

        StudentMarks SearchStudentMarks(int sem);

        bool UpdateStudent(StudentMarks stuMarks);

        ResponseModel DeleteStudentMarks(int stuId);
    }
}
