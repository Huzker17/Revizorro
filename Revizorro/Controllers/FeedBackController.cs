using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Revizorro.Models;
using Revizorro.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Revizorro.Controllers
{
    public class FeedBackController : Controller
    {
        private readonly ApplicationDbContext _db;
        IWebHostEnvironment _appEnvironment;

        public FeedBackController(ApplicationDbContext db, IWebHostEnvironment appEnvironment)
        {
            _db = db;
            _appEnvironment = appEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public OkObjectResult AddNew(FeedBack feedBack, Guid PlaceId)
        {
            if(feedBack != null && PlaceId != null)
            {
                feedBack.PlaceId = PlaceId;
                _db.FeedBacks.Add(feedBack);
                _db.SaveChanges();
                return Ok(feedBack);
            }
            else
            {
                return Ok("Incorrect dates");
            }
        }
        [HttpPost]
        public async Task<OkObjectResult> AddNewPhoto(AddNewPhotoViewModel model)
        {
            string Photo = string.Empty;
            Photo newPhoto = new Photo();
            if (model.Id != null && model.formFile != null)
            {
                var place = _db.Places.FirstOrDefault(x => x.Id == model.Id);
                    Photo = "/avatars/" + model.formFile.FileName;
                    newPhoto.Name = model.formFile.FileName;
                    newPhoto.MainPhoto = false;
                    newPhoto.PlaceId = place.Id;
                    using (var stream = new FileStream(_appEnvironment.WebRootPath + Photo, FileMode.Create))
                    {
                        await model.formFile.CopyToAsync(stream);
                    }
                place.MainPhoto = Photo;
                _db.Photos.Add(newPhoto);
                _db.Places.Update(place);
                _db.SaveChanges();
                return Ok(place);
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
