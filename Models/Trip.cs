using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismAPI.Models
{
    public class Trip
    {
        public int TripId { get; set; }
        public int UserId { get; set; }
        public int VendorId { get; set; }
        public int TripTypeId { get; set; }
        public string Source { get; set; }
        public string Date { get; set; }
        public string Status { get; set; }
        public decimal Budget { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}