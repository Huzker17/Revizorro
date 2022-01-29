using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revizorro.Models
{
    public class FeedBack
    {
        public Guid Id { get; set; }
        public Guid PlaceId { get; set; }
        public string Authour { get; set; }
        public string Description { get; set; }
        public float Rate { get; set; }
        public DateTime PublishedTime { get; set; }
        public Places Place { get; set; }
    }
}
