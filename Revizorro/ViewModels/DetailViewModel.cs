using Revizorro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revizorro.ViewModels
{
    public class DetailViewModel
    {
        public Places Place { get; set; }
        public List<Photo> Photo { get; set; }
        public List<FeedBack> FeedBacks { get; set; }
    }
}
