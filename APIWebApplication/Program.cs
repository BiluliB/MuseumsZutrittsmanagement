
using APIWebApplication.Data;
using APIWebApplication.Services;
using Microsoft.EntityFrameworkCore;


namespace MuseumsZutrittWebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add services to the container to programm.
            builder.Services.AddScoped<MuseumAreaService>();
            builder.Services.AddScoped<AccessLogService>();
            builder.Services.AddScoped<OpeningHourService>();
            builder.Services.AddScoped<VisitorCapacityService>();

            builder.Services.AddControllers();
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
