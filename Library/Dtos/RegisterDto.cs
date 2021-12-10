using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Dtos
{
   public class RegisterDto
    {
        public string Name { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
    }
}
