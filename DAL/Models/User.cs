using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class User
    {
        public int ClientId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }
        public ActivityLevel ActivityLevel { get; set; }
        public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
    }
}
