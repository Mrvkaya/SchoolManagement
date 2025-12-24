using System;
using System.Collections.Generic;
using System.Text;

namespace SMIS.Entities.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
    }
}
