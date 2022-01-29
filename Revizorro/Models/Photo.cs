using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revizorro.Models
{
    public class Photo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PathToPhoto { get; set; }
        public Guid PlaceId { get; set; }
        public bool MainPhoto { get; set; }
    }
}
