using System;
using System.Collections.Generic;
using System.Text;

namespace SMIS.Entities.Models
{
    public class Attendance
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public DateTime Date { get; set; }

        public bool IsPresent { get; set; }
    }
}
