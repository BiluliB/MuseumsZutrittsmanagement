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
                    ID = 1, 
                    AreaName = "Antike Kunst", 
                    AreaDescription = "Griechische und römische Skulpturen", 
                    AreaLocation = "1. Stock", 
                    AccessRules = "Kein Blitzlicht" },

                new MuseumArea { 
                    ID = 2, AreaName = "Moderne Kunst", 
                    AreaDescription = "Kunstwerke des 20. Jahrhunderts", 
                    AreaLocation = "2. Stock", 
                    AccessRules = "Keine Getränke erlaubt" }
            );

            // Hinzufügen von Seed-Daten für VisitorCapacity
            modelBuilder.Entity<VisitorCapacity>().HasData(
                new VisitorCapacity { 
                    ID = 1, 
                    MuseumAreaID = 1, 
                    MaxVisitorCount = 100 },
                new VisitorCapacity { 
                    ID = 2, 
                    MuseumAreaID = 2, 
                    MaxVisitorCount = 150 }
            );

            // Hinzufügen von Seed-Daten für OpeningHours
            modelBuilder.Entity<OpeningHour>().HasData(
                new OpeningHour { 
                    ID = 1, 
                    MuseumAreaID = 1, 
                    Weekday = "Montag", 
                    Opens = new TimeSpan(9, 0, 0), 
                    Closes = new TimeSpan(17, 0, 0) },
                new OpeningHour { 
                    ID = 2, 
                    MuseumAreaID = 1, 
                    Weekday = "Dienstag", 
                    Opens = new TimeSpan(9, 0, 0), 
                    Closes = new TimeSpan(17, 0, 0) },
                new OpeningHour { 
                    ID = 3, 
                    MuseumAreaID = 2, 
                    Weekday = "Montag", 
                    Opens = new TimeSpan(10, 0, 0), 
                    Closes = new TimeSpan(18, 0, 0) }
            );

            // Hinzufügen von Seed-Daten für AccessLog
            modelBuilder.Entity<AccessLog>().HasData(
                new AccessLog { 
                    ID = 1, MuseumAreaID = 1, 
                    EntryTime = DateTime.Now, 
                    ExitTime = DateTime.Now.AddHours(2), 
                    CurrentVisitorCount = 50 },
                new AccessLog { 
                    ID = 2, 
                    MuseumAreaID = 2, 
                    EntryTime = DateTime.Now, 
                    ExitTime = DateTime.Now.AddHours(3), 
                    CurrentVisitorCount = 75 }
            );
        }

    }
}
