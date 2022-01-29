using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Revizorro.Models;
using Revizorro.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Revizorro.Controllers
{
    public class PlacesController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<User> _userManager;
        IWebHostEnvironment _appEnvironment;


        public PlacesController(ApplicationDbContext db, UserManager<User> userManager, IWebHostEnvironment appEnvironment)
        {
            _db = db;
            _userManager = userManager;
            _appEnvironment = appEnvironment;
        }
        [HttpPost]
        public OkObjectResult NewIndex(int curPage)
        {
            var patients = _db.Places.ToList();
            var maxPage = (int)Math.Ceiling((double)patients.Count / 20);
            List<Places> page = new List<Places>();
            if (curPage == 0)
                page = patients.Take(20).ToList();
            else if (curPage > 1 && curPage < maxPage && curPage == 1)
                page = patients.Skip((curPage - 1) * 20).Take(20).ToList();
            else
                page = patients.Skip((curPage - 1) * 20).Take(patients.Count - ((curPage - 1) * 20)).ToList();
            PlacesPaginationViewModel patientPage = new PlacesPaginationViewModel
            {
                Places = page,
                CurPage = curPage,
                MaxPage = maxPage
            };
            return Ok(patientPage);
        }
        [HttpGet]
        public OkObjectResult Index(int curPage)
        {
            var patients = _db.Places.ToList();
            var maxPage = (int)Math.Ceiling((double)patients.Count / 20);
            List<Places> page = new List<Places>();
            if (curPage == 0)
                page = patients.Take(20).ToList();
            else if (curPage > 1 && curPage < maxPage && curPage == 1)
                page = patients.Skip((curPage - 1) * 20).Take(20).ToList();
            else
                page = patients.Skip((curPage - 1) * 20).Take(patients.Count - ((curPage - 1) * 20)).ToList();
            PlacesPaginationViewModel patientPage = new PlacesPaginationViewModel
            {
                Places = page,
                CurPage = curPage,
                MaxPage = maxPage
            };
            return Ok(patientPage);
        }
        [HttpPost]
        public async Task<OkObjectResult> AddNewPlace(NewPlaceViewModel model)
        {
            string Photo = string.Empty;
            Photo newPhoto = new Photo();
            if (model.Description != null && model.Name != null)
            {
                Places place = new Places() {Description = model.Description, Title = model.Name, Id = new Guid() };
                if (model.formFile != null)
                {
                    Photo = "/avatars/" + model.formFile.FileName;
                    newPhoto.Name = model.formFile.FileName;
                    newPhoto.MainPhoto = true;
                    newPhoto.PlaceId = place.Id;
                    using (var stream = new FileStream(_appEnvironment.WebRootPath + Photo, FileMode.Create))
                    {
                        await model.formFile.CopyToAsync(stream);
                    }
                }
                else
                {
                Photo = "/avatars/no-avatar-pic.jpg";
                }
                place.PlaceRating = 0;
                place.MainPhoto = Photo;
                _db.Photos.Add(newPhoto);
                _db.Places.Add(place);
                _db.SaveChanges();
                return Ok(place);
            }
            else
            {
                throw new Exception();
            }
        }
        public IActionResult Details(Guid id)
        {
            if (id != null)
            {
                var feedbacks = _db.FeedBacks.Where(x => x.PlaceId == id).ToList();
                var place = _db.Places.FirstOrDefault(x => x.Id == id);
                var photos = _db.Photos.Where(x => x.PlaceId == id).ToList();
                DetailViewModel model = new DetailViewModel()
                {
                    Place = place,
                    FeedBacks = feedbacks,
                    Photo = photos
                };
                return View(model);
            }
            else
            {
                throw new Exception();
            }
        }


    }
}
