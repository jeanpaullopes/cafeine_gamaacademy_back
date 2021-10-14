using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafeine_DinDin_Backend.Entities
{
    public class Professor
    {
        public string Id { get; set; }
        public string nome { get; set; }

        public Professor(string id, string nome)
        {
            Id = id;
            this.nome = nome;
        }
    }
}
