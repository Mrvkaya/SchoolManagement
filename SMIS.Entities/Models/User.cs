using System;
using System.Collections.Generic;
using System.Text;
using SMIS.Entities.Enums;

namespace SMIS.Entities.Models
{
    public class User
    {
        public int Id { get; set; } 
        public string Password { get; set; } 
        public UserRole Role { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; } 
        public string? ResetCode { get; set; }
        public DateTime? ResetCodeExpire { get; set; }
    }
}
