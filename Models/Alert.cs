using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismAPI.Models
{
    public class Alert
    {
        public int AlertId { get; set; }
        public int UserId { get; set; }
        public int DestinationId { get; set; }

        public string AlertMessage { get; set; }

        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}