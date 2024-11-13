using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCRentalMGR.Models;
using System.Threading.Tasks;

namespace PCRentalMGR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly PCRentalMGRContext _context;

        public RentalsController(PCRentalMGRContext context)
        {
            _context = context;
        }

        // GET: api/rentals
        [HttpGet]
        public async Task<IActionResult> GetRentals()
        {
            var rentals = await _context.Rentals
                .Include(r => r.User) // User情報を含める
                .Include(r => r.Device) // Device情報を含める
                .ToListAsync();

            return Ok(rentals);
        }

        // GET: api/rentals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rental>> GetRental(int id)
        {
            var rental = await _context.Rentals.FindAsync(id);
            var rentals = await _context.Rentals
            .Include(r => r.User)
            .Include(r => r.Device)
            .ToListAsync();

            if (rental == null)
            {
                return NotFound();
            }

            return rental;
        }

        // POST: api/rentals
        [HttpPost]
        public async Task<IActionResult> CreateRental([FromBody] Rental rental)
        {
            if (ModelState.IsValid)
            {
                var device = await _context.Devices.FindAsync(rental.DeviceId);
                if (device != null)
                {
                    device.IsRented = true; // 貸出中に設定
                    _context.Rentals.Add(rental);
                    await _context.SaveChangesAsync();
                    return Ok(rental);
                }
            }
            return BadRequest("貸出登録に失敗しました。");
        }



        // PUT: api/rentals/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRental(int id, [FromBody] Rental rental)
        {
            if (id != rental.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(rental).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentalExists(id))
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

        // DELETE: api/rentals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRental(int id)
        {
            var rental = await _context.Rentals.FindAsync(id);
            if (rental == null)
            {
                return NotFound();
            }

            _context.Rentals.Remove(rental);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RentalExists(int id)
        {
            return _context.Rentals.Any(e => e.Id == id);
        }

        //返却
        [HttpPost("{deviceId}/return")]
        public async Task<IActionResult> ReturnRental(int deviceId)
        {
            try
            {
                var rental = await _context.Rentals.FirstOrDefaultAsync(r => r.DeviceId == deviceId && r.IsRented);

                if (rental == null)
                {
                    return NotFound("返却対象が見つかりません。");
                }

                rental.IsRented = false;
                _context.Rentals.Update(rental);

                var device = await _context.Devices.FindAsync(deviceId);
                if (device != null)
                {
                    device.IsRented = false;
                    _context.Devices.Update(device);
                }

                await _context.SaveChangesAsync();

                return Ok("返却が完了しました。");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"サーバーエラー: {ex.Message}");
            }
        }


    }
}