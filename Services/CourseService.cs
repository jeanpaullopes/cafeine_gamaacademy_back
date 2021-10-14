using Cafeine_DinDin_Backend.Entities;
using Cafeine_DinDin_Backend.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafeine_DinDin_Backend.Services
{
    public class CourseService
    {
        private static CourseService instance;

        private CourseService()
        {

        }
        public static CourseService GetInstance()
        {
            if (instance == null)
            {
                instance = new CourseService();
            }
            return instance;
        }
        public List<Course> GetCourses()
        {

            CourseRepository _repo = CourseRepository.GetInstance();
            return _repo.FindAll();
        }

        public Course GetCourse(string id)
        {
            CourseRepository _repo = CourseRepository.GetInstance();
            return _repo.Find(id);
        }

        public Course PostCourse(Course course)
        {
            CourseRepository _repo = CourseRepository.GetInstance();
            return _repo.save(course);
        }

    }
}
