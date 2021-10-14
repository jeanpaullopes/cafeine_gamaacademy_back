using Cafeine_DinDin_Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafeine_DinDin_Backend.Repositories
{
    
    public class CourseRepository
    {

        private List<Course> courses = new List<Course>();

        private static CourseRepository instance;

        private CourseRepository()
        {
            
        }
        public static CourseRepository GetInstance() 
        {
            if (instance == null)
            {
                instance = new CourseRepository();
            }
            return instance;
        }
        public List<Course> findAll()
        {
            if(courses.Count == 0)
            {
                CreateAll();
            }
            return courses;
        }
        private void CreateAll()
        {
            for (int c = 1; c < 10; c++)
            {
                List<Lesson> lessons = new List<Lesson>();
                for (int l = 1; l < 4; l++)
                {
                    lessons.Add(new Lesson(l, "http://link_" + c + "_" + l, null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."));
                }
                Course course = new Course("" + c,
                                   "https://capa_" + c,
                                   new Professor("" + 1, "Prof. Pardal"),
                                   "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                                   lessons);
                courses.Add(course);
            }
        }
    }
}
