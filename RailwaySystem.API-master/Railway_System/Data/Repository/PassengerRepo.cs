using RailwaySystem.API.Data;
using RailwaySystem.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwaySystem.API.Repository
{
    public class PassengerRepo : IPassenger
    {
        private TrainDbContext trainDb;
        public PassengerRepo(TrainDbContext _trainDb)
        {
            trainDb = _trainDb;
        }
        public Passenger AddPassenger(Passenger Passenger)
        {
            string stCode = string.Empty;
            try
            {
                trainDb.Passenger.Add(Passenger);
                trainDb.SaveChanges();

                return Passenger;
            }
            catch (Exception ex)
            {
                //return ex.Message;
                stCode = "400";
            }
            return Passenger;
        }

        public string DeletePassenger(int PassengerId)
        {

            string Result = string.Empty;
            Passenger delete;

            try
            {
                delete = trainDb.Passenger.Find(PassengerId);

                if (delete != null)
                {
                    trainDb.Passenger.Remove(delete);
                  
                    trainDb.SaveChanges();
                    Result = "200";
                }
            }
            catch (Exception ex)
            {
                Result = "400";
            }
            finally
            {
                delete = null;
            }
            return Result;
        }

        public List<Passenger> GetAllPassengers()
        {
            
            List<Passenger> Passenger = null;
            try
            {
                Passenger = trainDb.Passenger.ToList();
                return Passenger;

            }
            catch (Exception ex)
            {

            }
            return Passenger;
        }

        public Passenger GetPassenger(int PassengerId)
        {
            Passenger Passenger = null;
            try
            {
                Passenger = trainDb.Passenger.Find(PassengerId);
                return Passenger;
            }
            catch (Exception ex)
            {

            }
            return Passenger;
        }

        public Passenger UpdatePassenger(int PassengerId, Passenger Passenger)
        {
            
            var Passengers = trainDb.Passenger.FirstOrDefault(q => q.PassengerId == PassengerId);
            try
            {
                if (Passengers != null)
                {
                    Passengers.PName = Passenger.PName;
                    Passengers.Age = Passenger.Age;
                    Passengers.gender = Passenger.gender;
                
                }
            }
            catch(Exception ex)
            {
                throw;
            }
            return Passengers;
        }
        public IEnumerable<Report> GetReport(int TrainId)
        {
            var Result = (from p in trainDb.Passenger
                          join b in trainDb.bookings on p.PassengerId equals b.PassengerId where b.TrainId==TrainId
                          select new Report
                          {
                              PassengerId = p.PassengerId,
                              PName = p.PName,
                              Age = p.Age,
                              gender = p.gender,
                              Class=p.Class,
                              BookingId=b.BookingId,
                              fare=b.fare,
                              Date = b.Date,
                              Status=b.Status,
                              SeatNum=b.SeatNum
                          }).ToList();
            return Result;
        }

    }
}
