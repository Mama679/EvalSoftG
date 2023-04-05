using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DbContext
{
    public class TravelContext: Microsoft.EntityFrameworkCore.DbContext
    {
        public TravelContext(DbContextOptions<TravelContext> options) : base(options)
        {

        }

        public DbSet<Drivers> Drivers { get; set; }
        public DbSet<Vehicles> Vehicles { get; set; }
        public DbSet<Routes> Routes { get; set; }
        public DbSet<Schedules> Schedules { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
