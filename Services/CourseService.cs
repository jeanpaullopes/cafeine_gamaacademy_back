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
        private CourseRepository _repo;
        public CourseService(ApplicationDBContext context)
        {
            _repo = new(context);
        }

        public List<Course> GetAllCourses()
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
        public int DeleteCourse(int id, string confirm)
        {
            int ret = 404;
            Course course = GetCourse(id);
            if (course != null)
            {
                if (confirm == "Yes")
                {
                    if (_repo.DeleteCourse(course))
                    {
                        ret = 204; // no-Content
                    }
                    else
                    {
                        ret = 418; // I’m a teapot
                    }

                }
                else
                {
                    ret = 401;  //unathorized 
                }
            }
            return ret;
        }


        public int DeleteCourseLesson(int id, int idLesson, string confirm)
        {
            int ret = 404;
            Course course = GetCourse(id);
            if (course != null && course.ContainsLesson(idLesson))
            {
                if (confirm == "Yes")
                {
                    _repo.DeleteLesson(course, idLesson);

                    if (_repo.save(course) != null)
                    {
                        ret = 204; // no-Content
                    }
                    else
                    {
                        ret = 418; // I’m a teapot
                    }

                }
                else
                {
                    ret = 401;  //unathorized 
                }
            }
            return ret;
        }


    }
    
}
