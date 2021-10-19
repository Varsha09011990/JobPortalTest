using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Models
{
    public class Jobs
    {
        [Key]
        public int jobid { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public long locationId { get; set; }
            public long departmentId { get; set; }
            public DateTime closingDate { get; set; }
    }
}
