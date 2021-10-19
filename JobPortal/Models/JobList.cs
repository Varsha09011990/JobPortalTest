using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Models
{
    public class JobList

    {
        public string searchKey { get; set; }
        public int pageNo { get; set; }
        public int pageSize { get; set; }
        public long locationId { get; set; }
        public long departmentId { get; set; }

    }
}
