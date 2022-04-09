using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentManagementSystem.Infrastructure;
using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Controllers
{
    public class StudentMarksController : Controller
    {
        private readonly IStudentMarksService _stuService;
        private readonly ILogger<StudentMarksController> _Logger;
        public StudentMarksController(IStudentMarksService appContext, ILogger<StudentMarksController> Logger)
        {
            _Logger = Logger;
            _stuService = appContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult AddStudentMarksById(StudentMarks stuMarks)
        {
            _Logger.LogInformation("student endpoint starts");
            try
            {

                _stuService.AddStudentMarks(stuMarks);

                _Logger.LogInformation("student endpoint completed");
            }
            catch (Exception ex)
            {
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.Message);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.InnerException);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex);
            }
            return Ok("Student Marks Added");
        }

        public ActionResult UpdateStudentMarks(StudentMarks course)
        {
            _Logger.LogInformation("student endpoint starts");
            bool stu;
            try
            {
                stu = _stuService.UpdateStudent(course);
                _Logger.LogInformation("student endpoint completed");
                return Ok(stu);
            }
            catch (Exception ex)
            {
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.Message);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.InnerException);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex);
                return BadRequest();
            }
        }

        public IActionResult DeleteStudentByStuID(int stuid)
        {
            _Logger.LogInformation("student endpoint starts");

            try
            {

                var responseModel = _stuService.DeleteStudentMarks(stuid);
                if (responseModel == null) return NotFound();
                _Logger.LogInformation("student endpoint completed");

                return Ok(responseModel);
            }
            catch (Exception ex)
            {
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.Message);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.InnerException);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex);
                return BadRequest();
            }
        }

        public ActionResult SearchStudent(int stuid)
        {
            _Logger.LogInformation("student endpoint starts");
            StudentMarks stud;
            try
            {
                stud = _stuService.SearchStudentMarks(stuid);
                _Logger.LogInformation("student endpoint completed");
            }

            catch (Exception ex)
            {
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.Message);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.InnerException);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex);
                return BadRequest("Not Found");
            }
            return Ok(stud);
        }
    }
}
