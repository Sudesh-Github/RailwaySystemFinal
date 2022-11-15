using RailwaySystem.API.Models;
using RailwaySystem.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwaySystem.API.Services
{
    public class FoodS
    {
        private IFood food;
        public FoodS(IFood _food)
        {
            food = _food;
        }
        public Food AddFood(Food Food)
        {
            return food.AddFood(Food);
        }
        public string DeleteFood(int FoodId)
        {
            return food.DeleteFood(FoodId);
        }
        //public Food UpdateFood(int FoodId, Food Food)
        //{
        //    return food.UpdateFood(FoodId, Food);
        //}
        public Food GetFood(int FoodId)
        {
            return food.GetFood(FoodId);
        }
        public List<Food> GetAllFoods()
        {
            return food.GetAllFoods();
        }
       //// public IEnumerable<Report> GetReport(int TrainId){
       //     return food.GetReport(TrainId);
       // }//
    }
}
