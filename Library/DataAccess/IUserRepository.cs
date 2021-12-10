using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess
{
    public interface IUserRepository
    {
        User Create(User user);
        History AddFood(History food);
        User GetByEmail(string email);
        User GetById(int id);
    }
}
