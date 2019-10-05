using Code_First_SQLite_Web_Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code_First_SQLite_Web_Api.Dal
{
    public class TutorielContext : DbContext
    {
        public TutorielContext(DbContextOptions<TutorielContext> options) : base(options)
        {
        }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Player> Players { get; set; }
    }
}
