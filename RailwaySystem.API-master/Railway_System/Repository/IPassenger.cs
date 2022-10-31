using RailwaySystem.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwaySystem.API.Repository
{
    public interface IPassenger
    {
        public Passenger UpdatePassenger(int PassengerId,Passenger passenger);
        public Passenger AddPassenger(Passenger passenger);
        public string DeletePassenger(int PassengerId);
        public Passenger GetPassenger(int PassengerId);
        public IEnumerable<Report> GetReport(int TrainId);
        public List<Passenger> GetAllPassengers();
    }
}
