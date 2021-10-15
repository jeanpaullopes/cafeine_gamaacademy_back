using Cafeine_DinDin_Backend.Entities;
using Cafeine_DinDin_Backend.Repositories;
using Cafeine_DinDin_Backend.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafeine_DinDin_Backend.Services
{
    public class ImageService
    {
        private ImageRepository _repo;

        public ImageService(ApplicationDBContext context)
        {
            _repo = new(context);
        }

        public List<Image> GetAllImages()
        {
            return _repo.FindAll();
        }

        public Image GetImage(int id)
        {
            return _repo.Find(id);
        }

        public async Task<Image> PostImage(Image image)
        {
            image.image = Conversor.DecodeFrom64ToBytes(image.image64);
            return await _repo.SaveImage(image);
        }
        public Image UpdateImage(Image image)
        {
            image.image = Conversor.DecodeFrom64ToBytes(image.image64);
            return _repo.UpdateImage(image);
        }
        public int DeleteImage(int id, string confirm)
        {
            int ret = 404;
            Image image = GetImage(id);
            if (image != null)
            {
                if (confirm == "Yes")
                {
                    if (_repo.DeleteImage(image))
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
