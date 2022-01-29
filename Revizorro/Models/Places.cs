using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revizorro.Models
{
    public class Places
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string MainPhoto { get; set; }
        public float PlaceRating { get; set; }
        public IEnumerable<FeedBack> FeedBacks { get; set; }
        public List<string> Photos { get; set; }
    }
}
