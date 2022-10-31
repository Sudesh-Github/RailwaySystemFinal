using Microsoft.EntityFrameworkCore;
using RailwaySystem.API.Data;
using RailwaySystem.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwaySystem.API.Repository
{
    public class SeatRepo:ISeat
    {
        private TrainDbContext _trainDb;

        public SeatRepo(TrainDbContext trainDb)
        {
            _trainDb = trainDb;
        }

        #region GetAllSeats
        public List<Seat> GetAllSeats()
        {
            List<Seat> seat = null;
            try
            {
                seat = _trainDb.seat.ToList();

            }
            catch (Exception ex)
            {

            }
            return seat;
        }
        #endregion

        #region GetSeat
        public Seat GetSeat(int SeatId)
        {
            Seat seat = null;
            try
            {
                seat = _trainDb.seat.Find(SeatId);
            }
            catch (Exception ex)
            {

            }
            return seat;
        }
        #endregion

        #region SaveSeat
        public string SaveSeat(Seat seat)
        {
            //string result = string.Empty;
            //try
            //{
                _trainDb.seat.Add(seat);
                _trainDb.SaveChanges();
                
                //result = "200";
            //}
            //catch (Exception ex)
            //{
            //    return ex.Message;
               
            //}

            return "Saved";
        }
        #endregion

        #region UpdateSeat
        public Seat UpdateSeat(int SeatId,Seat seat)
        {
            var _seat = _trainDb.seat.FirstOrDefault(n => n.SeatId == SeatId);
            try
            {
                if (_seat != null)
                {
                    _seat.FirstAC = seat.FirstAC;
                    _seat.SecondAC = seat.SecondAC;
                    _seat.Sleeper = seat.Sleeper;
                    _seat.Total = seat.Total;
                   
                    _trainDb.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }

            return _seat;
        }
        #endregion
    }
}
