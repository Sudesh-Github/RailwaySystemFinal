using RailwaySystem.API.Models;
using RailwaySystem.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwaySystem.API.Services
{
    public class SeatS
    {
        private ISeat _seatRepository;
        public SeatS(ISeat seatRepository)
        {
            _seatRepository = seatRepository;
        }
        public string SaveSeat(Seat Seat)
        {
            return _seatRepository.SaveSeat(Seat);
        }
        public Seat UpdateSeat(int SeatId,Seat seat)
        {
            return _seatRepository.UpdateSeat(SeatId,seat);
        }
        public Seat GetSeat(int SeatId)
        {
            return _seatRepository.GetSeat(SeatId);
        }
        public List<Seat> GetAllSeats()
        {
            return _seatRepository.GetAllSeats();
        }
    }
}
