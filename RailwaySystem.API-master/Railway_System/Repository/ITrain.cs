using RailwaySystem.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwaySystem.API.Repository
{
    public interface ITrain
    {
        public string SaveTrain(Train train);
        public string UpdateTrain(Train train);
        public string DeleteTrain(int TrainId);
        Train GetTrain(int TrainId);
        List<Train> GetAllTrains();
        public List<Train> SearchTrain(string ArrivalStation, string DepartureStation, DateTime date);
        //public List<Train> GetTrains(string ArrivalStation, string DepartureStation, DateTime date);
        public IEnumerable<SearchTrainModel> GetTrains2(string ArrivalStation, string DepartureStation, DateTime date);
    }
}
