using Cafeine_DinDin_Backend.Entities;
using Cafeine_DinDin_Backend.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafeine_DinDin_Backend.Services
{
    public class TeacherService
    {
        private TeacherRepository _repo;
        public TeacherService(ApplicationDBContext context)
        {
            _repo = new(context);
        }

        public List<Teacher> GetAllTeachers()
        {
            return _repo.FindAll();
        }

        public Teacher GetTeacher(int id)
        {
            return _repo.Find(id);
        }

        public async Task<Teacher> PostTeacher(Teacher teacher)
        {
            return await _repo.SaveTeacher(teacher);
        }
        public Teacher UpdateTeacher(Teacher teacher)
        {
            return _repo.UpdateTeacher(teacher);
        }
        public int DeleteTeacher(int id, string confirm)
        {
            int ret = 404;
            Teacher teacher = GetTeacher(id);
            if (teacher != null)
            {
                if (confirm == "Yes")
                {
                    if (_repo.DeleteTeacher(teacher))
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
