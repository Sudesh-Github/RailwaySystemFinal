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
    public class TicketController : ControllerBase
    {
        private TicketS ticketS;
        public TicketController(TicketS _ticketS)
        {
            ticketS = _ticketS;
        }
        [HttpPost("SaveTicket")]
        public IActionResult SaveTicket(Tickets ticket)
        {
            return Ok(ticketS.SaveTicket(ticket));
        }
        [HttpDelete("DeactTicket")]
        public IActionResult DeactTicket(int TicketId)
        {
            return Ok(ticketS.DeactTicket(TicketId));
        }
        [HttpPut("UpdateTicket")]
        public IActionResult UpdateTicket(Tickets ticket)
        {
            return Ok(ticketS.UpdateTicket(ticket));
        }
        [HttpGet("GetTicket")]
        public IActionResult GetTicket(int TicketId)
        {
            return Ok(ticketS.GetTicket(TicketId));
        }

        [HttpGet("GetAllTickets")]
        public List<Tickets> GetAllTickets()
        {
            return ticketS.GetAllTickets();
        }
    }
}

