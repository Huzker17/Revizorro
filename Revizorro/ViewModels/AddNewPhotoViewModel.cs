using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revizorro.ViewModels
{
    public class AddNewPhotoViewModel
    {
        public Guid Id { get; set; }
        public IFormFile formFile { get; set; }
    }
}
