using DomainModel.Models;
using FlightManagementWebAPI.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagementWebAPI.Repositories
{
    public class UserRepository
    {
        private readonly AirportSystemContext _airportSystemContext;
        public UserRepository(AirportSystemContext airportSystemContext)
        {
            _airportSystemContext = airportSystemContext;
        }

        public void AddUser(User user)
        {
            var users = _airportSystemContext.Users.ToList();
            foreach(var u in users)
            {
                if (!user.Username.Equals(u.Username))
                {
                    _airportSystemContext.Users.Add(user);
                    _airportSystemContext.SaveChanges();
                }

            }
        }

        public User GetUser(int userId)
        {
            return _airportSystemContext.Users.FirstOrDefault(user => user.Id == userId);
        }

        public List<User> GetUsers()
        {
            return _airportSystemContext.Users.ToList();
        }
    }
}
