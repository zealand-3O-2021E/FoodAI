using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Library.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;
        public UserRepository(UserContext context)
        {
            _context = context;
        }
        public User Create(User user)
        {
            _context.Users.Add(user);
            user.Id = _context.SaveChanges();
            return user;
        }

        public History AddFood(History food)
        {
            _context.Histories.Add(food);
            food.id = _context.SaveChanges();
            return food;
        }
        public User GetByEmail(string email)
        {
            return _context.Users.Include(a => a.Histories).FirstOrDefault(u => u.Email == email);
        }

        public User GetById(int id)
        {
            return _context.Users.Include(a => a.Histories).FirstOrDefault(u => u.Id == id);
        }
    }
}
