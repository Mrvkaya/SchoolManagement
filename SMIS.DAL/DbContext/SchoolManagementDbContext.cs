using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SMIS.Entities.Models;

namespace SMIS.DAL.Context
{
    public class SchoolManagementDbContext : DbContext
    {
        public SchoolManagementDbContext(DbContextOptions<SchoolManagementDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
