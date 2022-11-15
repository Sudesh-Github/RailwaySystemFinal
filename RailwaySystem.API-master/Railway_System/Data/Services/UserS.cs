using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RailwaySystem.API.Models;
using RailwaySystem.API.Repository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RailwaySystem.API.Services
{
    public class UserS
    {
        private IUser _userRepository;
        
        public UserS(IUser userRepository)
        {
            _userRepository = userRepository;
        }
        public double SaveUser(User user)
        {
            return _userRepository.SaveUser(user);
        }
        public string UpdateUser(User user)
        {
            return _userRepository.UpdateUser(user);
        }
        public User GetUserByEmail(string Email)
        {
            return _userRepository.GetUserbyEmail(Email);
        }
        public User GetUser(int UserId)
        {
            return _userRepository.GetUser(UserId);
        }
        public List<User> GetAllUser()
        {
            return _userRepository.GetAllUser();
        }


       
    }
}
