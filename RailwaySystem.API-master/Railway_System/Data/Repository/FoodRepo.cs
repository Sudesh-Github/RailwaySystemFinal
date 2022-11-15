using RailwaySystem.API.Data;
using RailwaySystem.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwaySystem.API.Repository
{
    public class FoodRepo : IFood
    {
        private TrainDbContext trainDb;
        public FoodRepo(TrainDbContext _trainDb)
        {
            trainDb = _trainDb;
        }
        public Food AddFood(Food Food)
        {
            string stCode = string.Empty;
            try
            {
                trainDb.Food.Add(Food);
                trainDb.SaveChanges();

                return Food;
            }
            catch (Exception ex)
            {
                //return ex.Message;
                stCode = "400";
            }
            return Food;
        }

        public string DeleteFood(int FoodId)
        {

            string Result = string.Empty;
            Food delete;

            try
            {
                delete = trainDb.Food.Find(FoodId);

                if (delete != null)
                {
                    trainDb.Food.Remove(delete);

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

        public List<Food> GetAllFoods()
        {

            List<Food> Food = null;
            try
            {
                Food = trainDb.Food.ToList();
                return Food;

            }
            catch (Exception ex)
            {

            }
            return Food;
        }

        public Food GetFood(int FoodId)
        {
            Food Food = null;
            try
            {
                Food = trainDb.Food.Find(FoodId);
                return Food;
            }
            catch (Exception ex)
            {

            }
            return Food;
        }

        //public Food UpdateFood(int FoodId, Food Food)
        //{

        //    //var Foods = trainDb.Food.FirstOrDefault(q => q.FoodId == FoodId);
        //    //try
        //    //{
        //    //    if (Foods != null)
        //    //    {
        //    //        Foods.PName = Food.PName;
        //    //        Foods.Age = Food.Age;
        //    //        Foods.gender = Food.gender;

        //    //    }
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    throw;
        //    //}
        //    //return Foods;
        //}
        //public IEnumerable<Report> GetReport(int TrainId)
        //{
        //    var Result = (from p in trainDb.Food
        //                  join b in trainDb.bookings on p.FoodId equals b.FoodId
        //                  where b.TrainId == TrainId
        //                  select new Report
        //                  {
        //                      FoodId = p.FoodId,
        //                      PName = p.PName,
        //                      Age = p.Age,
        //                      gender = p.gender,
        //                      Class = p.Class,
        //                      BookingId = b.BookingId,
        //                      fare = b.fare,
        //                      Date = b.Date,
        //                      Status = b.Status,
        //                      SeatNum = b.SeatNum
        //                  }).ToList();
        //    return Result;
        //}

    }
}
