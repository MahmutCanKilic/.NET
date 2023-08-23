
using Business.Manager;
using Data.Entity;
using DataAccess.Context;
using DataAccess.Interfaces;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
namespace EntityFrameWorkSQLite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddDbContext<MyContext>(c => c.UseSqlite(@"Data Source=C:\Users\P2635\Documents\EFCoreSqliteSample.db"));
            builder.Services.AddScoped<MyContext>();
            builder.Services.AddScoped<CarRepository>();
            builder.Services.AddScoped<BusRepository>();
            builder.Services.AddScoped<CustomerRepository>();
            builder.Services.AddScoped<CarManager>();
            builder.Services.AddScoped<BusManager>();
            builder.Services.AddScoped<CustomerManager>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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