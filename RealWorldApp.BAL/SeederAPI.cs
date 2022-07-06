using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealWorldApp.DAL;
using RealWorldApp.DAL.Entities;

namespace RealWorldApp.BAL
{
    public class SeederAPI
    {
        private readonly appDbContext _dbContext;

        public SeederAPI(appDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (!_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Users.Any())
                {
                    var users = getUsers();
                    _dbContext.Users.AddRange(users);
                    _dbContext.SaveChanges();
                }
            }
        }

        private List<User> getUsers()
        {
            var data = new List<User>
            {
                new User
                {
                    FirstName = "Jon",
                    LastName = "Cena",
                    Email = "asd@gmial.com"
                },
                new User
                {
                    FirstName = "Mark",
                    LastName = "Brooks",
                    Email = "123@gmail.com"
                },
                new User
                {
                    FirstName = "Bob",
                    LastName = "Boobson",
                    Email = "bob@gmail.com"
                }
            };
            return data;
        }
    }
}
