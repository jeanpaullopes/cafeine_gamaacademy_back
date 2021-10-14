using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafeine_DinDin_Backend.Entities
{
    public class Course
    {
        public Course(string id, string urlCover, Professor professor, string description, List<Lesson> classes)
        {
            Id = id;
            UrlCover = urlCover;
            this.professor = professor;
            Description = description;
            Classes = classes;
        }

        public string Id { get; set; }
        public string UrlCover { get; set; }
        public Professor professor {get; set;}
        public string Description { get; set; }

        public List<Lesson> Classes { get; set; }

    }
}
