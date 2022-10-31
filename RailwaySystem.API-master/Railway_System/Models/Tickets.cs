using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailwaySystem.API.Models
{
    public class Tickets
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TicketId { get; set; }


        [ForeignKey("TransId")]
        public int? TransId { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "DD/MM/YYYY Format")]
        public DateTime Date { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "hh:mm Format")]
        public DateTime Time { get; set; }
        public bool isActive { get; set; }
    }
}
