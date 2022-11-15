using RailwaySystem.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwaySystem.API.Repository
{
    public interface IFood
    {
        //public Food UpdateFood(int FoodId, Food Food);
        public Food AddFood(Food Food);
        public string DeleteFood(int FoodId);
        public Food GetFood(int FoodId);
        //public IEnumerable<Report> GetReport(int TrainId);
        public List<Food> GetAllFoods();
    }
}
