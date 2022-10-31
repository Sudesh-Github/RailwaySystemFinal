using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RailwaySystem.API.Models;
using RailwaySystem.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwaySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private BookingS _bookingS;
        public BookingController(BookingS bookingS)
        {
            _bookingS = bookingS; 
        }
        [HttpPost("SaveBooking")]
        public IActionResult SaveBooking(Booking Booking)
        {
            return Ok(_bookingS.SaveBooking(Booking));
        }
        [HttpDelete("DeleteBooking")]
        public IActionResult DeactBooking(int BookingId)
        {
            return Ok(_bookingS.DeactBooking(BookingId));
        }
        [HttpPut("UpdateBooking")]
        public IActionResult UpdateBooking(Booking Booking)
        {
            return Ok(_bookingS.UpdateBooking(Booking));
        }
        [HttpGet("GetBooking")]
        public IActionResult GetBooking(int BookingId)
        {
            return Ok(_bookingS.GetBooking(BookingId));
        }

        [HttpGet("GetAllBookings")]
        public List<Booking> GetAllBookings()
        {
            return _bookingS.GetAllBookings();
        }
       
        [HttpGet("CalculateFare")]
        public IActionResult CalculateFare(int TrainId, string Class, int PassengerId, int UserId)
        {
            return Ok(_bookingS.CalculateFare(TrainId, Class, PassengerId,UserId));
        }
        [HttpGet("ConfirmBooking")]
        public IActionResult ConfirmBooking(int BookingId)
        {
            return Ok(_bookingS.ConfirmBooking(BookingId));
        }
        [HttpGet("GetBookingHistory")]
       public IActionResult GetBookingByUserID(int UserId)
        {
            return Ok(_bookingS.GetBookingByUserID(UserId));
        }
        [HttpGet("GetBookingId")]
        public IActionResult GetBookingId(int PassengerId)
        {
            return Ok(_bookingS.GetBookingId(PassengerId));
        }
    }
}
