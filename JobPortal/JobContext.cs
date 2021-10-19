using JobPortal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal
{
    public class JobContext:DbContext
    {
        public JobContext(DbContextOptions<JobContext> options)
           : base(options)
        {
        }

        public DbSet<Jobs> Jobs { get; set; }
    }
}
