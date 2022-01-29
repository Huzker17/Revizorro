using Microsoft.AspNetCore.Http;
using Revizorro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revizorro.ViewModels
{
    public class NewPlaceViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile formFile { get; set; }
    }
}
