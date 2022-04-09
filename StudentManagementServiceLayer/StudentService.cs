using StudentManagementRepositoryLayer;
using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementServiceLayer
{
    class StudentService : IStudentService
    {
        public StudentMngmntDbContext _appContext;
        public StudentService(StudentMngmntDbContext appContext)
        {
            _appContext = appContext;
        }

        public async Task<IList<Student>> GetStudentList()
        {
            IList<Student> stud;

            try
            {
                await Task.Delay(1000);
                stud = _appContext.Set<Student>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return stud;
        }


        public Student SearchStudent(int stuId)
        {

            Student stud;

            try
            {
                stud = _appContext.Find<Student>(stuId);

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return stud;
        }



        public ResponseModel DeleteStudent(int stuid)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                var stu = SearchStudent(stuid);
                _appContext.Remove<Student>(stu);

                _appContext.SaveChanges();
                model.ISuccess = true;
                model.Message = " Employee records removed succesfully";
            }

            catch (Exception ex)
            {
                model.ISuccess = false;
                model.Message = " Error:" + ex.Message;
            }
            return model;
        }


        public void AddStudent(Student stu)
        {
            _appContext.Add<Student>(stu);
            _appContext.SaveChanges();
        }


        public bool EditStudent(Student stu)
        {
            var student = SearchStudent(stu.StudentID);

            if (student != null)
            {
                student.StudentCourse = stu.StudentCourse;
                _appContext.Update<Student>(stu);
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
    }
}
