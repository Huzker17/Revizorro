using Revizorro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revizorro.ViewModels
{
    public class PlacesPaginationViewModel
    {
        public IEnumerable<Places> Places { get; set; }
        public int CurPage { get; set; }
        public int MaxPage { get; set; }
    }
}
