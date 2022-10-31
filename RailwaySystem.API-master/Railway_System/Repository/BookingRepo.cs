using Microsoft.EntityFrameworkCore;
using RailwaySystem.API.Data;
using RailwaySystem.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwaySystem.API.Repository
{
    public class BookingRepo : IBooking
    {
        private TrainDbContext _trainDb;
        public BookingRepo(TrainDbContext trainDb)
        {
            _trainDb = trainDb;
        }
        public string DeactBooking(int BookingId)
        {
            string Result = string.Empty;
            Booking delete = null;
            try
            {
                delete = _trainDb.bookings.Find(BookingId);
                if(delete!= null)
                {
                    delete.Status = "CANCELLED";
                    _trainDb.SaveChanges();
                    Result = "200";
                }

            }
            catch(Exception ex)
            {
                Result = "400";
            }
            return Result;
            
        }

        public List<Booking> GetAllBookings()
        {
            string Result = string.Empty;
            List<Booking> bookings = null;
            try
            {
                bookings = _trainDb.bookings.ToList();

            }
            catch (Exception ex)
            {

            }
            return bookings;
        }

        public Booking GetBooking(int BookingId)
        {
            Booking booking = null;
            try
            {
                booking = _trainDb.bookings.Find(BookingId);
            }
            catch (Exception ex)
            {

            }
            return booking;
        }

        public string SaveBooking(Booking booking)
        {
            string stCode = string.Empty;
            try
            {
                _trainDb.bookings.Add(booking);
                _trainDb.SaveChanges();
                stCode = "200";
            }
            catch (Exception ex)
            {
                stCode = "400";
            }
            return stCode;
        }

        public string UpdateBooking(Booking booking)
        {
            string stCode = string.Empty;
            try
            {
                _trainDb.Entry(booking).State = EntityState.Modified;
                _trainDb.SaveChanges();
                stCode = "200";
            }
            catch
            {
                stCode = "400";
            }
            return stCode;
        }

        #region Fare

        public double CalculateFare(int TrainId, string Class, int PassengerId,int UserId)
        {
            double fare = 0.00;
            var train = _trainDb.trains.Find(TrainId);
            int distance = (int)train.distance;
            Seat seat = _trainDb.seat.FirstOrDefault(q => q.TrainId == TrainId);
            if (Class == "FirstAC")
            {
                fare = ((8 * distance) + 250 + 70) * 0.18;
                seat.FirstAC = seat.FirstAC - 1;
            }
            if (Class == "SecondAC")
            {
                fare = ((6 * distance) + 150 + 50) * 0.18;
                seat.SecondAC = seat.SecondAC - 1;
            }
            if (Class == "Sleeper")
            {
                fare = ((4 * distance) + 50 + 30) * 0.18;
                seat.Sleeper = seat.Sleeper- 1;
            }
            Random rnd = new Random();
            int seatNum = rnd.Next(1, 72);
            _trainDb.bookings.Add(new Booking { TrainId = TrainId, Classes = Class, Status = "Pending", Date = DateTime.Now, PassengerId = PassengerId, SeatNum = seatNum,fare=fare,UserId=UserId });
            _trainDb.Entry(seat).State = EntityState.Modified;//to reduce seat
            _trainDb.SaveChanges();
            return fare;
        }
        #endregion

        #region ConfirmBooking
        public Booking ConfirmBooking(int BookingId)
        {
            string Result = string.Empty;
            Booking confirm = null;
           
            try
            {
                confirm = _trainDb.bookings.Find(BookingId);
                if (confirm != null)
                {
                    confirm.Status = "CONFIRM";
                    _trainDb.transaction.Add(new Transaction { BookingId = BookingId, TransactionStatus = "Success", Fare = confirm.fare });
                    _trainDb.SaveChanges();
                    Result = "200";
                }

            }
            catch (Exception ex)
            {
                Result = "400";
            }
            return confirm;

        }
        #endregion

        public IEnumerable<Booking> GetBookingByUserID(int UserId)
        {
            var booking = _trainDb.bookings.Where(a => a.UserId==UserId).ToList();
            
            return booking;
        }
        public int GetBookingId(int PassengerId)
        {

            Booking booking = _trainDb.bookings.FirstOrDefault(q => q.PassengerId == PassengerId);
            int BookingId = booking.BookingId;
            return BookingId;

        }
        

    }
    }
