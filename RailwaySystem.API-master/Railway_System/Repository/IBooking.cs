using RailwaySystem.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwaySystem.API.Repository
{
   public interface IBooking
    {
        public string SaveBooking(Booking booking);
        public string UpdateBooking(Booking booking);
        public string DeactBooking(int BookingId);
        public Booking ConfirmBooking(int BookingId);
        public IEnumerable<Booking> GetBookingByUserID(int UserId);
        public int GetBookingId(int PassengerId);
        Booking GetBooking(int BookingId);
        public double CalculateFare(int TrainId, string Class, int PassengerId,int UserId);
        List<Booking> GetAllBookings();
    }
}
