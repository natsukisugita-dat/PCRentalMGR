using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCRentalMGR.Models; // 名前空間を適宜変更

namespace PCRentalMGR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly PCRentalMGRContext _context;

        public DevicesController(PCRentalMGRContext context)
        {
            _context = context;
        }

        // GET: api/devices
        /*[HttpGet]
        public async Task<ActionResult<IEnumerable<Device>>> GetDevices()
        {
            return await _context.Devices.ToListAsync();
        }*/

        /*[HttpGet]
        public async Task<ActionResult<IEnumerable<Device>>> GetAvailableDevices()
        {
            return await _context.Devices
                .Where(device => device.Canrental == true)  // 貸出中の機器を除外
                .ToListAsync();
        }*/

        // GET: api/devices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Device>>> GetDevices()
        {
            return await _context.Devices.ToListAsync();
        }


        // GET: api/devices/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Device>> GetDevice(int id)
        {
            var device = await _context.Devices.FindAsync(id);

            if (device == null)
            {
                return NotFound();
            }

            return device;
        }

        // POST: api/devices
        [HttpPost]
        public async Task<ActionResult<Device>> CreateDevice(Device device)
        {
            if (_context.Devices.Any(d => d.Asset_no == device.Asset_no))
            {
                return Conflict("この資産番号は既に存在しています。");
            }

            device.register_date = DateTime.Now;
            device.edit_date = DateTime.Now;

            _context.Devices.Add(device);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDevice), new { id = device.Id }, device);
        }

        // PUT: api/devices/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDevice(int id, Device device)
        {
            if (id != device.Id)
            {
                return BadRequest();
            }

            var existingDevice = await _context.Devices.FindAsync(id);
            if (existingDevice == null)
            {
                return NotFound();
            }

            existingDevice.Asset_no = device.Asset_no;
            existingDevice.Maker = device.Maker;
            existingDevice.Model = device.Model;
            existingDevice.Os = device.Os;
            existingDevice.Memory = device.Memory;
            existingDevice.Capacity = device.Capacity;
            existingDevice.Gpu = device.Gpu;
            existingDevice.Store = device.Store;
            existingDevice.Failure = device.Failure;
            existingDevice.start = device.start;
            existingDevice.limit = device.limit;
            existingDevice.remaker = device.remaker;
            existingDevice.edit_date = DateTime.Now;

            _context.Devices.Update(existingDevice);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/devices/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevice(int id)
        {
            var device = await _context.Devices.FindAsync(id);
            if (device == null)
            {
                return NotFound();
            }

            _context.Devices.Remove(device);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Device>>> SearchDevices(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return await _context.Devices.ToListAsync();
            }

            var filteredDevices = await _context.Devices
                .Where(d => d.Asset_no.Contains(searchTerm) ||
                            d.Maker.Contains(searchTerm) ||
                            d.Model.Contains(searchTerm))
                .ToListAsync();

            return Ok(filteredDevices);
        }

    }
}
