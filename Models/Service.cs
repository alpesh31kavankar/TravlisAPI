using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismAPI.Models
{
    public class Service
    {
        public int ServiceId { get; set; }
        public int VendorServiceId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Photo { get; set; }
        public string Status { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}