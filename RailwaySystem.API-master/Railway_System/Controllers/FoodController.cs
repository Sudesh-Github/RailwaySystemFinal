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
    public class FoodController : ControllerBase
    {
        private FoodS FoodS;
        public FoodController(FoodS _FoodS)
        {
            FoodS = _FoodS;
        }
        [HttpPost("AddFood")]
        public IActionResult AddFood(Food Food)
        {
            return Ok(FoodS.AddFood(Food));
        }
        [HttpDelete("DeleteFood")]
        public IActionResult DeleteFood(int FoodId)
        {
            return Ok(FoodS.DeleteFood(FoodId));
        }
        [HttpPut("UpdateFood")]
        //public IActionResult UpdateFood(int FoodId, Food Food)
        //{
        //    //return Ok(FoodS.DeleteFood(FoodId, Food));
        //}
        [HttpGet("GetFood")]
        public IActionResult GetFood(int FoodId)
        {
            return Ok(FoodS.GetFood(FoodId));
        }

        [HttpGet("GetAllFoods")]
        public List<Food> GetAllFoods()
        {
            return FoodS.GetAllFoods();
        }
        //[HttpGet("GetReport")]
        ////public IEnumerable<Report> GetReport(int TrainId)
        ////{
        ////    return FoodS.GetReport(TrainId);
        ////}
    }
}
