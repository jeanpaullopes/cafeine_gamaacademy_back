using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafeine_DinDin_Backend.Entities
{
    public class Lesson
    {
        public int ID { get; set; }
        public int order { get; set; }
        public string Link { get; set; }
        public string  UrlImage { get; set; }
       public string Description { get; set; }

        public Lesson(int order, string link, string urlImage, string description)
        {
            this.order = order;
            Link = link;
            UrlImage = urlImage;
            Description = description;
        }
    }
}
