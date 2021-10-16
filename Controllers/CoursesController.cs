using Cafeine_DinDin_Backend.Entities;
using Cafeine_DinDin_Backend.Repositories;
using Cafeine_DinDin_Backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafeine_DinDin_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoursesController : ControllerBase
    {
        
        private CourseService _courseService;

        public CoursesController(ApplicationDBContext context)
        {
            _courseService = new(context);
                 
        }

        [HttpGet]
        public ActionResult<List<Course>> Get()
        {
         
            return _courseService.GetAllCourses();
        }

        [HttpGet("{id}", Name = "GetCourse ")]
        public ActionResult<Course> Get(int id)
        {
            var course = _courseService.GetCourse(id);
            //tratamento para caso não encontre
            if (course == null)
            {
                return NotFound();
            }

            return course;
        }

        [HttpPost]
        public Task<Course> Create(Course course)
        {
            return _courseService.PostCourse(course); 
        }
        [HttpPut]
        public Course Update(Course course)
        {
            return _courseService.UpdateCourse(course);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id, string confirm) 
        {
            int _operation = _courseService.DeleteCourse(id, confirm);
            HttpContext.Response.StatusCode = _operation;

            return new EmptyResult(); 
        }

        [HttpDelete("{id}/Lessons/{idLesson}")]
        public ActionResult DeleteLesson(int id, int idLesson, string confirm)
        {
            int _operation = _courseService.DeleteCourseLesson(id, idLesson, confirm);
            HttpContext.Response.StatusCode = _operation;

            return new EmptyResult();
        }
    }
}
