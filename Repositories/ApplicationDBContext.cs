using Cafeine_DinDin_Backend.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafeine_DinDin_Backend.Repositories
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<Course> courses{ get; set; }
        public DbSet<Teacher> teachers { get; set; }
        public DbSet<Lesson> lessons { get; set; }
        public DbSet<Image> images{ get; set; }

    }
}
