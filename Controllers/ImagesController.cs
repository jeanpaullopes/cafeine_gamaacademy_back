using Cafeine_DinDin_Backend.Entities;
using Cafeine_DinDin_Backend.Repositories;
using Cafeine_DinDin_Backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafeine_DinDin_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImagesController : ControllerBase
    {
        private ImageService _imageService;
        public ImagesController(ApplicationDBContext context)
        {
            _imageService = new(context);

        }
        
        [HttpGet("{id}")]
        public FileStreamResult Get(int id)
        {
            var image = _imageService.GetImage(id);
            //tratamento para caso não encontre
            if (image != null)
            {
                var stream = new System.IO.MemoryStream(image.image);
                return new FileStreamResult(stream, new MediaTypeHeaderValue("image/jpeg"))
                {
                    FileDownloadName = $"{image.ID}.jpg"
                };
            } else
            {
                HttpContext.Response.StatusCode = NotFound().StatusCode;
                return null;
            }

            
        }
        [HttpPost]
        public Task<Image> Create(Image image)
        {
            return _imageService.PostImage(image);
        }
        [HttpPut]
        public Image Update(Image image)
        {
            return _imageService.UpdateImage(image);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id, string confirm)
        {
            int _operation = _imageService.DeleteImage(id, confirm);
            HttpContext.Response.StatusCode = _operation;

            return new EmptyResult();
        }
    }
}
