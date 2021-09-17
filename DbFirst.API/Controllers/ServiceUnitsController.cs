using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DbFirst.API.Models.PostgreSQL;

namespace DbFirst.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceUnitsController : ControllerBase
    {
        private readonly WZSHRContext _context;

        public ServiceUnitsController(WZSHRContext context)
        {
            _context = context;
        }

        // GET: api/ServiceUnits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceUnit>>> GetServiceUnits()
        {
            return await _context.ServiceUnits.ToListAsync();
        }

        // GET: api/ServiceUnits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceUnit>> GetServiceUnit(string id)
        {
            var serviceUnit = await _context.ServiceUnits.FindAsync(id);

            if (serviceUnit == null)
            {
                return NotFound();
            }

            return serviceUnit;
        }

        // PUT: api/ServiceUnits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceUnit(string id, ServiceUnit serviceUnit)
        {
            if (id != serviceUnit.Id)
            {
                return BadRequest();
            }

            _context.Entry(serviceUnit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceUnitExists(id))
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

        // POST: api/ServiceUnits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ServiceUnit>> PostServiceUnit(ServiceUnit serviceUnit)
        {
            _context.ServiceUnits.Add(serviceUnit);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ServiceUnitExists(serviceUnit.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetServiceUnit", new { id = serviceUnit.Id }, serviceUnit);
        }

        // DELETE: api/ServiceUnits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceUnit(string id)
        {
            var serviceUnit = await _context.ServiceUnits.FindAsync(id);
            if (serviceUnit == null)
            {
                return NotFound();
            }

            _context.ServiceUnits.Remove(serviceUnit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceUnitExists(string id)
        {
            return _context.ServiceUnits.Any(e => e.Id == id);
        }
    }
}
