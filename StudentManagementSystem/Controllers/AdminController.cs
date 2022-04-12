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
    public class AdminController : Controller
    {
        private readonly IStudentService _stuService;
        private readonly ILogger<AdminController> _Logger;
        private readonly IStudentMarksService _stuMarksService;

        public AdminController(IStudentService stuService, IStudentMarksService stuMarksService, ILogger<AdminController> Logger)
        {
            _Logger = Logger;
            _stuService = stuService;
            _stuMarksService = stuMarksService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetAllStudents()
        {
            _Logger.LogInformation("student endpoint starts");
            var student = await _stuService.GetStudentList();
            try
            {
                if (student == null) return NotFound();
                _Logger.LogInformation("student endpoint completed");
            }
            catch (Exception ex)
            {
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.Message);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.InnerException);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex);
                return BadRequest();
            }
            //return Ok(student);
            return View(student);
        }

        public ActionResult DeleteStudent(int Id)
        {
            var student = _stuService.SearchStudent(Id);
            if (student == null)
            {
                return BadRequest();
            }
            else
            {
                var responseModel = _stuService.DeleteStudent(Id);
                ViewBag.Message = string.Format("Student Deleted Successfully");
                return View(student);
            }
        }
        public async Task<IActionResult> GetAllStudentsMarks()
        {
            _Logger.LogInformation("student endpoint starts");
            var student = await _stuMarksService.GetStudentMarksList();
            try
            {

                if (student == null) return NotFound();

                _Logger.LogInformation("student endpoint completed");
            }
            catch (Exception ex)
            {
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.Message);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.InnerException);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex);
                return BadRequest();
            }
            return Ok(student);
        }

        public ActionResult EditStudent (int Id)
        {
            var student = _stuService.SearchStudent(Id);
            if (student == null)
            {
                return BadRequest();
            }
            else
            {
                return View(student);
            }
        }

        [HttpPost]
        public ActionResult EditStudent(Student course)
        {
            _Logger.LogInformation("student endpoint starts");
            bool stu;
            try
            {
                stu = _stuService.EditStudent(course);
                _Logger.LogInformation("student endpoint completed");
                //return Ok(stu);
                return View(course);
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
