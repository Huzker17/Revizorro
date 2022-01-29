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
        public OkObjectResult AddNew(AddFeedBackViewModel model)
        {
            if(model.FeedBack != null && model.Id != null)
            {
                model.FeedBack.PlaceId = model.Id;
                _db.FeedBacks.Add(model.FeedBack);
                _db.SaveChanges();
                return Ok(model.FeedBack);
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
                    Photo = "/photos/" + model.formFile.FileName;
                    newPhoto.Name = model.formFile.FileName;
                    newPhoto.MainPhoto = false;
                    newPhoto.PlaceId = place.Id;
                    using (var stream = new FileStream(_appEnvironment.WebRootPath + Photo, FileMode.Create))
                    {
                        await model.formFile.CopyToAsync(stream);
                    }
                newPhoto.PathToPhoto = Photo;
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
