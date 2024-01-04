using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismAPI.Models
{
    public class Gallery
    {
        public int GalleryId { get; set; }
        public int UserId { get; set; }
        public int TripId { get; set; }

        public string Title { get; set; }
        public string SubTitle { get; set; }

        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}