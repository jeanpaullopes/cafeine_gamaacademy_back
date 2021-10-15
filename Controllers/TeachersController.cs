using Cafeine_DinDin_Backend.Entities;
using Cafeine_DinDin_Backend.Repositories;
using Cafeine_DinDin_Backend.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafeine_DinDin_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeachersController : ControllerBase
    {
        private TeacherService _teacherService;
        public TeachersController(ApplicationDBContext context)
        {
            _teacherService = new(context);

        }
        [HttpGet]
        public ActionResult<List<Teacher>> Get()
        {

            return _teacherService.GetAllTeachers();
        }

        [HttpGet("{id}")]
        public ActionResult<Teacher> Get(int id)
        {
            var teacher = _teacherService.GetTeacher(id);
            //tratamento para caso não encontre
            if (teacher == null)
            {
                return NotFound();
            }

            return teacher;
        }
        [HttpPost]
        public Task<Teacher> Create(Teacher teacher)
        {
            return _teacherService.PostTeacher(teacher);
        }
        [HttpPut]
        public Teacher Update(Teacher teacher)
        {
            return _teacherService.UpdateTeacher(teacher);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id, string confirm)
        {
            int _operation = _teacherService.DeleteTeacher(id, confirm);
            HttpContext.Response.StatusCode = _operation;

            return new EmptyResult(); 
        }
    }
}
