using Microsoft.EntityFrameworkCore;
using APIWebApplication.Models;


namespace APIWebApplication.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<AccessLog> AccessLog { get; set; }
        public DbSet<MuseumArea> MuseumAreas { get; set; }
        public DbSet<OpeningHour> OpeningHour { get; set; }
        public DbSet<VisitorCapacity> VisitorCapacity { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies();
                
            }
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Hinzufügen von Seed-Daten für MuseumAreas
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

            // Hinzufügen von Seed-Daten für VisitorCapacity
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

            // Hinzufügen von Seed-Daten für OpeningHours
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

            // Hinzufügen von Seed-Daten für AccessLog
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
