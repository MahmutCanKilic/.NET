using System.Formats.Asn1;

namespace ExtensionMethod
{
    public static class Extensions
    {

        public static void VehiclePassingTime(this Vehicle vehicleProp)
        {

            Console.WriteLine(vehicleProp.stopTime);


        }
    }
    internal class Program
    {

        
        static void Main(string[] args)
        {

            Console.WriteLine("Car -> C     Bus -> B");

            Bus otobus = new Bus();
            otobus.Name = "Otobüs";

            Car car = new Car();
            car.Name = "BMW";

            Car car2 = new Car();
            car2.Name = "Mercedes";

            ConsoleKeyInfo cki = Console.ReadKey();

            if (cki.Key == ConsoleKey.B)
            {
                otobus.VehicleMove();
            }
            else if (cki.Key == ConsoleKey.C)
            {
                car.VehicleMove();
            }
            else if (cki.Key == ConsoleKey.F1)
            {
                Environment.Exit(0);
            }
            DataBase dataBase = new DataBase();
            
            dataBase.Add(car);
            dataBase.Add(car2);
            dataBase.Add(otobus);
            dataBase.ShowList();
            foreach (var vehicle in dataBase.vehicles)
            {
                if (vehicle.Name == "BMW")
                {
                    Console.WriteLine("BMW bulundu");
                    break;
                }
            }
            if (dataBase.vehicles.Contains(car))
            {
                Console.WriteLine("BMW bulundu 2");
                Console.WriteLine(dataBase.vehicles.BinarySearch(car));
            }

            

            
        }
    }
    public class Vehicle
    {
        
        public bool isRunning;
        public virtual void VehicleMove() { }
        public virtual void VehicleStop() { }
        public int stopTime;
        public string Name { get; set; }

    }
    public class Bus : Vehicle
    {

        public ConsoleKeyInfo cki;
        public override void VehicleMove()
        {
            Console.WriteLine("Otobüsü çalıştır  Y/N");
            cki = Console.ReadKey();

            if (cki.Key == ConsoleKey.Y)
            {
                isRunning = true;
                Console.WriteLine("Otobüs hareket ediyor");
            }
            else if (cki.Key == ConsoleKey.N)
            {
                Console.WriteLine("Otobüsü durdur");
                stopTime = DateTime.Now.Second;
                isRunning = false;
            }
        }
    }
    public class Car : Vehicle
    {

        public override void VehicleMove()
        {
            Console.WriteLine("Araba çalışıyor mu?  Y/N");
            ConsoleKeyInfo cki = Console.ReadKey();

            if (cki.Key == ConsoleKey.Y)
            {
                isRunning = true;
                Console.WriteLine("Araba hareket ediyor");
            }
            else if (cki.Key == ConsoleKey.N)
            {
                Console.WriteLine("Araba çalışmıyor");
                stopTime = DateTime.Now.Second;
                isRunning = false;
            }
        }

    }
    public class DataBase
    {

        public List<Vehicle> vehicles = new List<Vehicle>();
        public void Add(Car car)
        {
            
            vehicles.Add(car);
            Console.WriteLine("Car eklendi");
        }
        public void Add(Bus bus)
        {
            vehicles.Add(bus);
            Console.WriteLine("Bus eklendi");
        }
        public void ShowList()
        {
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle.Name);
            }
        }

    }

}