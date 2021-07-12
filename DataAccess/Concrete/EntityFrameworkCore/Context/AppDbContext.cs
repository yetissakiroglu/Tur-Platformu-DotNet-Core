using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Entities.Concrete.EntityFrameworkCore.Context
{
    public class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-5MA6AVU\SQLEXPRESS; Initial Catalog=TourDb1; Integrated Security=True; Persist Security Info=False");
            base.OnConfiguring(optionsBuilder);

        }

        //public DbSet<comments> comments { get; set; }
        //public DbSet<free_services> free_services { get; set; }
        public DbSet<Location> Locations { get; set; }
        //public DbSet<note> note { get; set; }
        //public DbSet<paid_services> paid_services { get; set; }
        //public DbSet<prices> prices { get; set; }
        //public DbSet<tour> tour { get; set; }
        //public DbSet<tour_date> tour_date { get; set; }
        //public DbSet<tour_free_services> tour_free_services { get; set; }
        //public DbSet<tour_image> tour_image { get; set; }
        //public DbSet<tour_note> tour_note { get; set; }
        //public DbSet<tour_paid_services> tour_paid_services { get; set; }
        //public DbSet<tour_program> tour_program { get; set; }
        //public DbSet<tour_program_location> tour_program_location { get; set; }

    }
}
