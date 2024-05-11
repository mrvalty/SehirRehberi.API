using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehberi.API.Models
{
    public class User : BaseEntity
    {
        public User()
        {
            Cities = new List<City>();
        }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string UserName { get; set; }

        public List<City> Cities { get; set; }
    }
}
