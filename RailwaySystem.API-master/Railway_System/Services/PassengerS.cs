using RailwaySystem.API.Models;
using RailwaySystem.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwaySystem.API.Services
{
    public class PassengerS
    {
        private IPassenger passenger;
        public PassengerS(IPassenger _passenger)
        {
            passenger = _passenger;
        }
        public Passenger AddPassenger(Passenger Passenger)
        {
            return passenger.AddPassenger(Passenger);
        }
        public string DeletePassenger(int PassengerId)
        {
            return passenger.DeletePassenger(PassengerId);
        }
        public Passenger UpdatePassenger(int PassengerId,Passenger Passenger)
        {
            return passenger.UpdatePassenger(PassengerId, Passenger);
        }
        public Passenger GetPassenger(int PassengerId)
        {
            return passenger.GetPassenger(PassengerId);
        }
        public List<Passenger> GetAllPassengers()
        {
            return passenger.GetAllPassengers();
        }
        public IEnumerable<Report> GetReport(int TrainId)
        {
            return passenger.GetReport(TrainId);
        }
    }
}
