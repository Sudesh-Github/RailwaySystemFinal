using Microsoft.EntityFrameworkCore;
using RailwaySystem.API.Data;
using RailwaySystem.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwaySystem.API.Repository
{
    public class TicketRepo : ITicket
    {
        private TrainDbContext _TicketDb;
        public TicketRepo(TrainDbContext TicketDbContext)
        {
            _TicketDb = TicketDbContext;
        }
        #region DeleteTicket
        /// <summary>
        /// Deactivates the Ticket when this fuction is invoked
        /// </summary>
        /// <param name="TicketId"></param>
        /// <returns>If the TicketId is present then isActive is changed to false</returns>
        public string DeactTicket(int TicketId)
        {

            string Result = string.Empty;
            Tickets delete;

            try
            {
                delete = _TicketDb.tickets.Find(TicketId);

                if (delete != null)
                {
                    //_TicketDb.TicketsDb.Remove(delete);
                    delete.isActive = false;
                    _TicketDb.SaveChanges();
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
        #endregion

        #region GetAllTickets
        /// <summary>
        /// When the function is invoked we get the list of all Tickets 
        /// </summary>
        /// <returns>List of Ticket</returns>
        public List<Tickets> GetAllTickets()
        {
            string Result = string.Empty;
            List<Tickets> Tickets = null;
            try
            {
                Tickets = _TicketDb.tickets.ToList();

            }
            catch (Exception ex)
            {

            }
            return Tickets;
        }
        #endregion

        #region GetTicket
        /// <summary>
        /// When this function is invocked we get the Tickets by Id
        /// </summary>
        /// <param name="TicketId"></param>
        /// <returns>Finds the Id of the Ticket</returns>
        public Tickets GetTicket(int TicketId)
        {
            Tickets Ticket = null;
            try
            {
                Ticket = _TicketDb.tickets.Find(TicketId);
            }
            catch (Exception ex)
            {

            }
            return Ticket;
        }
        #endregion

        #region AddTicket
        /// <summary>
        /// When this function is invoked we can Add a Ticket
        /// </summary>
        /// <param name="Ticket"></param>
        /// <returns></returns>
        public string SaveTicket(Tickets Ticket)
        {
            string stCode = string.Empty;
            try
            {
                _TicketDb.tickets.Add(Ticket);
                _TicketDb.SaveChanges();
                stCode = "200";
            }
            catch (Exception ex)
            {
                stCode = "400";
            }
            return stCode;
        }

       
        #endregion

        #region UpdateTicket
        /// <summary>
        /// When this function is invoked we will be able to Update Ticket details
        /// </summary>
        /// <param name="Ticket"></param>
        /// <returns>Updated Ticket Details</returns>
        public string UpdateTicket(Tickets Ticket)
        {
            string stCode = string.Empty;
            try
            {
                _TicketDb.Entry(Ticket).State = EntityState.Modified;
                _TicketDb.SaveChanges();
                stCode = "200";
            }
            catch
            {
                stCode = "400";
            }
            return stCode;

        }
        #endregion
    }
}
