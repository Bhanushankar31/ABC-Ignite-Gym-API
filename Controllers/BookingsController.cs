using Microsoft.AspNetCore.Mvc;
using ABCIgnite.Models;
using System.Collections.Generic;
using System.Linq;

namespace ABCIgnite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private static List<Booking> bookings = new List<Booking>();
        private static List<ClassModel> classes = new List<ClassModel>(); // You would use in-memory class list here as well

        [HttpPost]
        public IActionResult CreateBooking([FromBody] BookingRequest request)
        {
            var classToBook = classes.FirstOrDefault(c => c.Id == request.ClassId);
            if (classToBook == null)
                return NotFound("Class not found.");

            if (request.ParticipationDate <= DateTime.UtcNow || request.ParticipationDate < classToBook.StartDate || request.ParticipationDate > classToBook.EndDate)
                return BadRequest("Invalid participation date.");

            // Count the existing bookings for the class on this date
            var existingBookings = bookings.Where(b => b.ClassId == request.ClassId && b.ParticipationDate.Date == request.ParticipationDate.Date).Count();
            if (existingBookings >= classToBook.Capacity)
                return BadRequest("Class is already fully booked.");

            var booking = new Booking
            {
                Id = bookings.Count + 1,
                MemberName = request.MemberName,
                ClassId = request.ClassId,
                ParticipationDate = request.ParticipationDate
            };
            bookings.Add(booking);
            return CreatedAtAction(nameof(CreateBooking), new { id = booking.Id }, booking);
        }

        [HttpGet]
        public IActionResult SearchBookings([FromQuery] string? memberName = null, [FromQuery] DateTime? startDate = null, [FromQuery] DateTime? endDate = null)
        {
            var query = bookings.AsEnumerable();

            if (!string.IsNullOrEmpty(memberName))
                query = query.Where(b => b.MemberName.Contains(memberName));

            if (startDate.HasValue)
                query = query.Where(b => b.ParticipationDate >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(b => b.ParticipationDate <= endDate.Value);

            var result = query.Select(b => new
            {
                b.Id,
                ClassName = classes.FirstOrDefault(c => c.Id == b.ClassId)?.Name,
                b.ParticipationDate,
                b.MemberName
            });

            return Ok(result);
        }
    }
}
