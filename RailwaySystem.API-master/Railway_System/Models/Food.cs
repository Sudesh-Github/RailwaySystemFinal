using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace RailwaySystem.API.Models
{
    public class Food
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FoodId { get; set; }

        //public int TrainId { get; set; }

        public string FoodType { get; set; }

        public Boolean IsNeeded { get; set; }
       
    }
}
