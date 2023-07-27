using DataAccess;
using MySql.Data.MySqlClient;

namespace AdoNetMySqlExample
{

    public class Program
    {
        public static ToDo toDo = new ToDo();
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");


            string cmd;
            string temp;
            do
            {
                temp = Console.ReadLine();
                switch (temp)
                {
                    case "insert":
                        Console.WriteLine("enter description and name");
                        toDo.Insert(Console.ReadLine(), Console.ReadLine()); ;
                        break;
                    case "read":
                        Console.WriteLine("enter table name");
                        toDo.Read(Console.ReadLine());
                        break;
                    case "delete":
                        Console.WriteLine("enter id");
                        toDo.Delete(Convert.ToInt32(Console.ReadLine()));
                        break;
                    case "update":
                        Console.WriteLine("enter id,description,name");
                        toDo.Update(Convert.ToInt32(Console.ReadLine()), Console.ReadLine(), Console.ReadLine());
                        break;
                    default:
                        Console.WriteLine("Geçersiz komut");
                        break;
                }
            } while (temp != "exit");


            app.Run();
        }
    }
    public class ToDo
    {
        PhoneRepository phoneRepository = new PhoneRepository();
        public void Insert(string insertDescription, string insertName)
        {
            phoneRepository.DBInsert(insertDescription, insertName);
        }
        public void Delete(int deleteId)
        {
            phoneRepository.DBDelete(deleteId);
        }
        public void Read(string column)
        {
            phoneRepository.DBRead(column);
        }
        public void Update(int id, string description, string name)
        {
            phoneRepository.DBUpdate(id, description, name);
        }
    }
}