using Microsoft.EntityFrameworkCore;
using APIWebApplication.Models;


namespace APIWebApplication.Data
{
    /// <summary>
    /// Represents the database context for the API web application, handling entities such as access logs, museum areas, opening hours, and visitor capacities.
    /// </summary>
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the AppDbContext class with the specified configuration.
        /// </summary>
        /// <param name="configuration">The configuration interface for accessing settings.</param>
        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<AccessLog> AccessLogs { get; set; }
        public DbSet<MuseumArea> MuseumAreas { get; set; }
        public DbSet<OpeningHour> OpeningHours { get; set; }
        public DbSet<VisitorCapacity> VisitorCapacities { get; set; }

        /// <summary>
        /// Configures the model building for the database context, including setting up seed data.
        /// </summary>
        /// <param name="modelBuilder">The builder used to define the model for the context.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Adding seed data for MuseumAreas
            modelBuilder.Entity<MuseumArea>().HasData(
                new MuseumArea { 
                    Id = 1, 
                    AreaName = "Antike Kunst", 
                    AreaDescription = "Griechische und römische Skulpturen", 
                    AreaLocation = "1. Stock", 
                    AccessRules = "Kein Blitzlicht" },

                new MuseumArea { 
                    Id = 2, AreaName = "Moderne Kunst", 
                    AreaDescription = "Kunstwerke des 20. Jahrhunderts", 
                    AreaLocation = "2. Stock", 
                    AccessRules = "Keine Getränke erlaubt" }
            );

            // Adding seed data for VisitorCapacity
            modelBuilder.Entity<VisitorCapacity>().HasData(
                new VisitorCapacity { 
                    Id = 1, 
                    MuseumAreaId = 1, 
                    MaxVisitorCount = 100 },
                new VisitorCapacity { 
                    Id = 2, 
                    MuseumAreaId = 2, 
                    MaxVisitorCount = 150 }
            );

            // Adding seed data for OpeningHours
            modelBuilder.Entity<OpeningHour>().HasData(
                new OpeningHour { 
                    Id = 1, 
                    MuseumAreaId = 1, 
                    Weekday = "Montag", 
                    Opens = new TimeSpan(9, 0, 0), 
                    Closes = new TimeSpan(17, 0, 0) },
                new OpeningHour { 
                    Id = 2, 
                    MuseumAreaId = 1, 
                    Weekday = "Dienstag", 
                    Opens = new TimeSpan(9, 0, 0), 
                    Closes = new TimeSpan(17, 0, 0) },
                new OpeningHour { 
                    Id = 3, 
                    MuseumAreaId = 2, 
                    Weekday = "Montag", 
                    Opens = new TimeSpan(10, 0, 0), 
                    Closes = new TimeSpan(18, 0, 0) }
            );

            // Adding seed data for AccessLog
            modelBuilder.Entity<AccessLog>().HasData(
                new AccessLog { 
                    Id = 1, MuseumAreaId = 1, 
                    EntryTime = DateTime.Now, 
                    ExitTime = DateTime.Now.AddHours(2), 
                    CurrentVisitorCount = 50 },
                new AccessLog { 
                    Id = 2, 
                    MuseumAreaId = 2, 
                    EntryTime = DateTime.Now, 
                    ExitTime = DateTime.Now.AddHours(3), 
                    CurrentVisitorCount = 75 }
            );
        }

    }
}
