using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reada_Backend.Models
{
    public class UserModel
    {
        

        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public byte[] PassHash { get; set; }

        public byte[] SaltePass { get; set; }
    }
}
