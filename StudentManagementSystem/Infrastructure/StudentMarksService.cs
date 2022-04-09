using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Infrastructure
{
    public class StudentMarksService : IStudentMarksService
    {
        public StudentMngmntDbContext _appContext;
        public StudentMarksService(StudentMngmntDbContext appContext)
        {
            _appContext = appContext;
        }

        public async Task<IList<StudentMarks>> GetStudentMarksList()
        {
            IList<StudentMarks> studMarks;

            try
            {
                await Task.Delay(1000);
                studMarks = _appContext.Set<StudentMarks>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return studMarks;
        }


        public void AddStudentMarks(StudentMarks stuMarks)
        {
            _appContext.Add<StudentMarks>(stuMarks);
            _appContext.SaveChanges();
        }

        public bool UpdateStudent(StudentMarks stu)
        {
            var student = SearchStudentMarks(stu.StudentID);

            if (student != null)
            {
                student.StuMarks = stu.StuMarks;
                _appContext.Update<StudentMarks>(stu);
            }

            if (_appContext.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public StudentMarks SearchStudentMarks(int stuid)
        {
            StudentMarks stud;

            try
            {
                stud = _appContext.Find<StudentMarks>(stuid);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return stud;
        }


        public ResponseModel DeleteStudentMarks(int stuid)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                var stud = SearchStudentMarks(stuid);
                _appContext.Remove<StudentMarks>(stud);

                _appContext.SaveChanges();
                model.ISuccess = true;
                model.Message = " Student marks records removed succesfully";
            }

            catch (Exception ex)
            {
                model.ISuccess = false;
                model.Message = " Error:" + ex.Message;
            }
            return model;
        }
    }
}
