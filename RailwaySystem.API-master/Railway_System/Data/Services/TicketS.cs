using RailwaySystem.API.Models;
using RailwaySystem.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwaySystem.API.Services
{
    public class TicketS
    {
        private ITicket _ITicket;
        public TicketS(ITicket ITicket)
        {
            _ITicket = ITicket;
        }
        public string SaveTicket(Tickets Ticket)
        {
            return _ITicket.SaveTicket(Ticket);
        }
        public string DeactTicket(int TicketId)
        {
            return _ITicket.DeactTicket(TicketId);
        }
        public string UpdateTicket(Tickets Ticket)
        {
            return _ITicket.UpdateTicket(Ticket);
        }
        public Tickets GetTicket(int TicketId)
        {
            return _ITicket.GetTicket(TicketId);
        }
        public List<Tickets> GetAllTickets()
        {
            return _ITicket.GetAllTickets();
        }
    }
}
