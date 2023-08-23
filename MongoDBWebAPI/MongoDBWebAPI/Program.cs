
using Business.Managers;
using Data;
using Data.Entity;
using DataAccess.Repos;
using System.Security.Cryptography.X509Certificates;

namespace MongoDBWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
           // builder.Services.Configure<DbSettings>(builder.Configuration.GetSection("ProductsDatabase"));
            builder.Services.AddScoped<DatabaseContext>();
            builder.Services.AddScoped<ProductRepository>();
            builder.Services.AddScoped<ProductManager>();
            builder.Services.AddScoped<DbSettings>();
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