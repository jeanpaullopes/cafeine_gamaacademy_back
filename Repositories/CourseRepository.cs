using Cafeine_DinDin_Backend.Entities;
using Cafeine_DinDin_Backend.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafeine_DinDin_Backend.Repositories
{
    
    public class CourseRepository
    {

        private readonly ApplicationDBContext _context;
        public CourseRepository(ApplicationDBContext context)
        {
            _context = context;    
        }
        
        public List<Course> FindAll()
        {
            //uso do Include para carga ansiosa / Eager load
            return _context.courses.Include(c => c.Teacher).Include(c => c.Lessons).ToList();
        }

        public Course Find(int id)
        {
            return _context.courses.FirstOrDefault(c => c.ID == id); 
        }

        public Course save(Course course)
        {
            
            return course;
        }
        public async Task<Course> SaveCourse(Course course)
        {
            try
            {
                var result = await _context.AddAsync(course);
                await _context.SaveChangesAsync();

                return result.Entity;

            }
            catch (Exception e)
            {
                return null;
            }

        }
        public Course UpdateCourse(Course course)
        {
            try
            {
                var result = _context.Update(course);
                
                return result.Entity;

            }
            catch (Exception e)
            {
                return null;
            }

        }

    }
}
