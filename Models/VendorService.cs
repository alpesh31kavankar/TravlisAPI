using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismAPI.Models
{
    public class VendorService
    {
        public int VendorServiceId { get; set; }
        public int VendorId { get; set; }
        public int DestinationId { get; set; }
        public int ServiceId { get; set; }
        public decimal ServiceCost { get; set; }
        public string Status { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}