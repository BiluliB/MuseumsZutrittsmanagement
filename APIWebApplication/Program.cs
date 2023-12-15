
using APIWebApplication.Common;
using APIWebApplication.Data;
using APIWebApplication.Interfaces;
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
            builder.Services.AddScoped<IAccessLogService, APIWebApplication.Services.AccessLogService>();
            builder.Services.AddScoped<OpeningHourService>();
            builder.Services.AddScoped<VisitorCapacityService>();


            builder.Services.AddControllers();
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowLocalhost",
                    policy =>
                {
                    policy.WithOrigins("http://localhost:5173")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("AllowLocalhost");

            app.MapControllers();

            app.Run();
        }
    }
}
