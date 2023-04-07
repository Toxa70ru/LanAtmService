using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Domain.authorization
{
    public class Reg_User
    {
        public int User_id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Midlename { get; set; }
        public DateOnly Birthday { get; set; }
        public string Phone_Number { get; set; }   
        public int Role_id { get; set; }
        public string Login { get; set;}
        public string Password { get; set;}
    }
}
