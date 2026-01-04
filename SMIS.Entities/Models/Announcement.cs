using System;
using System.Collections.Generic;
using System.Text;

namespace SMIS.Entities.Models
{
    public class Announcement
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
