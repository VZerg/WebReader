using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BashReaderMVS.Models
{
    public class PostViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public int PostId { get; set; }
        public int Rating { get; set; }
        public Guid Id { get; set; }
        public DateTime PublishDate { get; set; }
    }
}