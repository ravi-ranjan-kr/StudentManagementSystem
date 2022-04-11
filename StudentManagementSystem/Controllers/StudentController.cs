using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentManagementSystem.Infrastructure;
using StudentManagementSystem.Models;
using System;
using System.Threading.Tasks;

namespace StudentManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _stuService;
        private readonly ILogger<StudentController> _Logger;

        public StudentController(IStudentService appContext, ILogger<StudentController> Logger)
        {
            _Logger = Logger;
            _stuService = appContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult SearchStudentById(int stuid)
        {
            _Logger.LogInformation("student endpoint starts");
            Student stu;
            try
            {
                stu = _stuService.SearchStudent(stuid);

                _Logger.LogInformation("student endpoint completed");
            }

            catch (Exception ex)
            {
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.Message);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.InnerException);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex);
                return BadRequest("Not Found");
            }
            return Ok(stu);
        }

        public ActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(Student stu)
        {
            _Logger.LogInformation("student endpoint starts");
            try
            {
                _stuService.AddStudent(stu);
                _Logger.LogInformation("student endpoint completed");
            }
            catch (Exception ex)
            {
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.Message);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.InnerException);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex);
            }
            ViewBag.Message = string.Format("Student Added Successfully");
            return View();
        }

        public ActionResult EditStudent(Student course)
        {
            _Logger.LogInformation("student endpoint starts");
            bool stu;
            try
            {
                stu = _stuService.EditStudent(course);
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
    }
}
