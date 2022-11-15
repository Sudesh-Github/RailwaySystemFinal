using Microsoft.EntityFrameworkCore;
using RailwaySystem.API.Data;
using RailwaySystem.API.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RailwaySystem.API.Repository
{
    public class UserRepo : IUser
    {
        private TrainDbContext _trainDb;

        public UserRepo(TrainDbContext trainDb)
        {
            _trainDb = trainDb;
        }

        #region GetAllUser
        public List<User> GetAllUser()
        {
            List<User> users = null;
            try
            {
                users = _trainDb.users.ToList();
            }
            catch (Exception ex)
            {

            }

            return users;
        }
        #endregion

       

        #region Get User By email
        public User GetUserbyEmail(string Email)
        {
            User email = null;
            try
            {
                email = _trainDb.users.FirstOrDefault(q => q.Email == Email);
            }
            catch(Exception ex)
            {

            }
            return email;
        }
        #endregion

        #region GetUserById

        public User GetUser(int UserId)
        {
            User user = null;
            try
            {
                user = _trainDb.users.Find(UserId);
               
            }
            catch (Exception ex)
            {

            }
            return user;
        }
        #endregion

        #region SaveUser
        public double SaveUser(User user)
        {
            double message = 0.00;
            try
            {
                User userd = GetUserbyEmail(user.Email);
                if (userd != null)
                {
                    message = 1.00;
                }
                else
                {
                    _trainDb.users.Add(user);

                    _trainDb.SaveChanges();

                    message = 0.00;

                }


            }
            catch (Exception ex)
            {

            }

            return message;
        }
        #endregion

        #region UpdateUser
        public string UpdateUser(User user)
        {
            string Result = string.Empty;
            try
            {
                _trainDb.Entry(user).State = EntityState.Modified;
                _trainDb.SaveChanges();
                Result = "200";
            }
            catch (Exception ex)
            {
                Result = "400";
            }
            return Result;
        }
        #endregion
    }
}
