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
    public class CourseController : ControllerBase
    {
        
        private CourseService _courseService;

        public CourseController(ApplicationDBContext context)
        {
            _courseService = new(context);// courseService;
                 
        }

        [HttpGet]
        public ActionResult<List<Course>> Get()
        {
         
            return _courseService.GetCourses();
        }

        [HttpGet("{id}", Name = "GetCourse ")]
        public ActionResult<Course> Get(int id)
        {
            var course = _courseService.GetCourse(id);
            //tratamento para caso não encontre
            if (course == null)
            {
                return null;
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
    }
}
