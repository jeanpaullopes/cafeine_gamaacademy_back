using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cafeine_DinDin_Backend.Entities
{
    public class Image
    {
        public int ID {get; set;}
        public byte[] image { get; set; }

        [NotMapped]
        public string image64 { get; set; }
    }
}
