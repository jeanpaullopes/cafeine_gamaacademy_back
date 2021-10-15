using Cafeine_DinDin_Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafeine_DinDin_Backend.Repositories
{
    public class ImageRepository
    {
        private readonly ApplicationDBContext _context;
        public ImageRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public List<Image> FindAll()
        {
            //uso do Include para carga ansiosa / Eager load
            return _context.images.ToList();
        }

        public Image Find(int id)
        {
            var teer = _context.images.Find(id);
            return teer;
        }

        public Image save(Image image)
        {

            return image;
        }
        public async Task<Image> SaveImage(Image image)
        {
            try
            {
                var result = await _context.AddAsync(image);
                await _context.SaveChangesAsync();

                return result.Entity;

            }
            catch (Exception e)
            {
                return null;
            }

        }
        public Image UpdateImage(Image image)
        {
            try
            {
                var result = _context.Update(image);
                _context.SaveChanges();
                return result.Entity;

            }
            catch (Exception e)
            {
                return null;
            }

        }
        public bool DeleteImage(Image image)
        {
            try
            {
                var result = _context.Remove(image);
                _context.SaveChanges();
                return (result.Entity.ID == image.ID);
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}
