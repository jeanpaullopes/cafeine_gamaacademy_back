using Cafeine_DinDin_Backend.Entities;
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
        
        private readonly ILogger<CourseController> _logger;

        public CourseController(ILogger<CourseController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<Course>> Get()
        {
         
            return CourseService.GetInstance().GetCourses();
        }

        [HttpGet("{id}", Name = "GetCourse ")]
        public ActionResult<Course> Get(string id)
        {
            var course = CourseService.GetInstance().GetCourse(id);
            //tratamento para caso não encontre
            if (course == null)
            {
                return null;
            }

            return course;
        }

        [HttpPost]
        public ActionResult<Course> Create(Course course)
        {
            return CourseService.GetInstance().PostCourse(course); 
        }
    }
}
