using DeliveryChargeAPI.DBContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeliveryChargeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        private readonly DeliveryDbContext _context;

        public DeliveryController(DeliveryDbContext context)
        {
            _context = context;
        }

        [HttpPost("CalculateCharge")]
        public async Task<IActionResult> CalculateCharge([FromBody] DeliveryRequest request)
        {
            var shopAddress = await _context.Addresses.FindAsync(request.ShopAddressId);
            var deliveryAddress = await _context.Addresses.FindAsync(request.DeliveryAddressId);

            if (shopAddress == null || deliveryAddress == null)
            {
                return NotFound("Address not found");
            }

            var distance = DistanceCalculator.CalculateDistance(
                shopAddress.Latitude, shopAddress.Longitude,
                deliveryAddress.Latitude, deliveryAddress.Longitude);

            var deliveryCharge = await _context.DeliveryCharges
                .OrderBy(dc => dc.Distance)
                .FirstOrDefaultAsync(dc => dc.Distance >= distance);

            return Ok(new { Distance = distance, Charge = deliveryCharge?.Charge ?? 0 });
        }
    }

    public class DeliveryRequest
    {
        public int ShopAddressId { get; set; }
        public int DeliveryAddressId { get; set; }
    }
}

