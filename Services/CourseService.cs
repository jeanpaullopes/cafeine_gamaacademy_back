using Cafeine_DinDin_Backend.Entities;
using Cafeine_DinDin_Backend.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafeine_DinDin_Backend.Services
{
    public class CourseService : ICourseService
    {
        private CourseRepository _repo;
        public CourseService(ApplicationDBContext context)
        {
            _repo = new(context);
        }
      
        public List<Course> GetCourses()
        {
            return _repo.FindAll();
        }

        public Course GetCourse(int id)
        {
            return _repo.Find(id);
        }

        public async Task<Course> PostCourse(Course course)
        {
            return await _repo.SaveCourse(course);
        }
        public Course UpdateCourse(Course course)
        {
            return _repo.UpdateCourse(course);
        }

    }
    public interface ICourseService
    {
        public List<Course> GetCourses();
        public Course GetCourse(int id);
        public Task<Course> PostCourse(Course course);
        
    }
}
