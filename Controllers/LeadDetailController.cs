using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeAssignment.Models;

namespace PracticeAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadDetailController : ControllerBase
    {
        private readonly LeadDetailsContext _context;

        public LeadDetailController(LeadDetailsContext context)
        {
            _context = context;
        }

        // GET: api/LeadDetail
        [HttpGet]
        public IEnumerable<LeadDetails> GetLeadDetails()
        {
            return _context.LeadDetails;
        }

        // GET: api/LeadDetail/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLeadDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var leadDetails = await _context.LeadDetails.FindAsync(id);

            if (leadDetails == null)
            {
                return NotFound();
            }

            return Ok(leadDetails);
        }

        // PUT: api/LeadDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeadDetails([FromRoute] int id, [FromBody] LeadDetails leadDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != leadDetails.leadId)
            {
                return BadRequest();
            }

            _context.Entry(leadDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeadDetailsExists(id))
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

        // POST: api/LeadDetail
        [HttpPost]
        public async Task<IActionResult> PostLeadDetails([FromBody] LeadDetails leadDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.LeadDetails.Add(leadDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLeadDetails", new { id = leadDetails.leadId }, leadDetails);
        }

        // DELETE: api/LeadDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeadDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var leadDetails = await _context.LeadDetails.FindAsync(id);
            if (leadDetails == null)
            {
                return NotFound();
            }

            _context.LeadDetails.Remove(leadDetails);
            await _context.SaveChangesAsync();

            return Ok(leadDetails);
        }

        private bool LeadDetailsExists(int id)
        {
            return _context.LeadDetails.Any(e => e.leadId == id);
        }
    }
}