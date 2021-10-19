using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobPortal;
using JobPortal.Models;

namespace JobPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly JobContext _context;

        public JobsController(JobContext context)
        {
            _context = context;
        }

        // GET: api/JobDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jobs>>> GetJobs()
        {
            return await _context.Jobs.ToListAsync();
        }

        // GET: api/JobDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Jobs>> GetJobDetails(int id)
        {
            var jobDetails = await _context.Jobs.FindAsync(id);

            if (jobDetails == null)
            {
                return NotFound();
            }

            return jobDetails;
        }

        // PUT: api/JobDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobDetails(int id, Jobs details)
        {
            if (id != details.jobid)
            {
                return BadRequest();
            }

            _context.Entry(details).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobDetailsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/JobDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Jobs>> PostJobDetails(Jobs details)
        {
            _context.Jobs.Add(details);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobDetails", new { id = details.jobid }, details);
        }

        // POST: api/JobDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<Jobs>> SerachJobDetails(JobList list)
        //{

    //        var jobDetails = await _context.Jobs
    //.Where(b =>b.pageNo)
    //.OrderBy(b => b)
    //.Select(b => new SelectListItem
    //{
    //    Value = b.Id,
    //    Text = b.Name
    //})
    //.ToListAsync();

        //    if (jobDetails == null)
        //    {
        //        return NotFound();
        //    }

        //    return jobDetails;
        //}

        // DELETE: api/JobDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Jobs>> DeleteJobDetails(int id)
        {
            var jobDetails = await _context.Jobs.FindAsync(id);
            if (jobDetails == null)
            {
                return NotFound();
            }

            _context.Jobs.Remove(jobDetails);
            await _context.SaveChangesAsync();

            return jobDetails;
        }

        private bool JobDetailsExists(int id)
        {
            return _context.Jobs.Any(e => e.jobid == id);
        }
    }
}
