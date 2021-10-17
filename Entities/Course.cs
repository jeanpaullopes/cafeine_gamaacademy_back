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


        public bool ContainsLesson(int idLesson)
        {
            bool ret = false;
            Lessons.ForEach(l => { if (l.ID == idLesson) { ret = true; } });
            return ret;
        }
        public void DeleteLesson(int idLesson)
        {
            for (int i = Lessons.Count -1; i >= 0; i--)
            {
                if (Lessons.ElementAt(i).ID == idLesson)
                {
                    Lessons.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
