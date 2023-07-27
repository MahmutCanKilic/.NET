
using SQLiteExample.Controllers;

namespace SQLiteExample
{
    public class Program
    {

        public static void Main(string[] args)
        {
            #region WEBAPI
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
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
            #endregion
            string temp;
            SQLiteSample sQLiteSample = new SQLiteSample();
            do
            {


                temp = Console.ReadLine();
                switch (temp)
                {
                    case "insert":
                        Console.WriteLine("yeni veri satýrý için product, price ve test verilerini girin");
                        sQLiteSample.InsertTable(Console.ReadLine(), Convert.ToInt32(Console.ReadLine()), Console.ReadLine());
                        break;
                    case "read":
                        Console.WriteLine("tablo ismi girin");
                        sQLiteSample.ReadTable(Console.ReadLine());
                        break;
                    case "update":
                        Console.WriteLine("price ve id girin");
                        sQLiteSample.UpdateData(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));
                        break;
                    case "delete":
                        Console.WriteLine("silinecek satýrýn id'si");
                        sQLiteSample.DeleteData(Convert.ToInt32(Console.ReadLine()));
                        break;
                    default:
                        Console.WriteLine("geçersiz komut");
                        break;
                }
            } while (temp != "exit");



            app.Run();
        }
    }
}