using RailwaySystem.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwaySystem.API.Repository
{
    public interface IUser
    {
        public double SaveUser(User user);
        public string UpdateUser(User user);
        User GetUser(int UserId);
        User GetUserbyEmail(string Email);
        List<User> GetAllUser();
    }
}
