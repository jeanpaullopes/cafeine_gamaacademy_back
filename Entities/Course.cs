using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafeine_DinDin_Backend.Entities
{
    public class Course
    {
        

        public int ID { get; set; }
        public string UrlCover { get; set; }
        public Teacher Teacher {get; set;}
        public string Description { get; set; }
public List<Lesson> Lessons { get; set; }

    }
}
