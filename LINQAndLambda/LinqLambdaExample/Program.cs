using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace LinqLambdaExample
{
    internal class Program
    {
        #region Main
        static void Main(string[] args)
        {
            Linq linq = new Linq();
            foreach (var item in linq.Where())
            {
                Console.WriteLine(item.name + "  " + item.price + "  " + item.speed);
            }
            linq.Select();
            linq.SelectMany();
            linq.Join();
            linq.GroupJoin2();
            linq.GroupBy();
            linq.Except();
        }
        #endregion
    }
    class Linq
    {

        DataAccess data = new DataAccess();

        public IEnumerable<Cars> carInfo;
        #region Where
        public IEnumerable<Cars> Where()
        {
            List<Cars> cars = new List<Cars>(); 
            data.AddCar();
            carInfo = data.cars.Where(x => x.price >= 100);

            return carInfo;
        }
  
        #endregion
        #region Select
        public void Select()
        {
            data.cars.Where(x => x.price >= 150).Select(x => x.price * x.speed).ToList().ForEach(x => Console.WriteLine(x));

        }
        #endregion
        #region SelectMany
        public void SelectMany()
        {
            List<string> animals = new List<string>() { "cat", "dog", "donkey" };
            List<int> number = new List<int>() { 10, 20 };
            var a = number.SelectMany(x => animals, (x, y) => new { x, y });

        }
        #endregion
        #region Join
        public void Join()
        {
            int[] sayilistesi1 = new int[] { 1, 2, 5, 6, 9 };
            int[] sayilistesi2 = new int[] { 1, 2, 4, 6, 7 };
            sayilistesi1.Join(sayilistesi2, x => x, y => y, (x, y) => x).ToList().ForEach(x => Console.WriteLine(x));
        }
        #endregion
        #region GroupJoin

        class Country
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        class City
        {
            public int Id { get; set; }
            public int CountryId { get; set; }
            public string Name { get; set; }
        }

        public void GroupJoin2()
        {
            Country[] countries = new Country[]
            {
               new Country{Id = 1, Name = "Türkiye"},
               new Country{Id = 2, Name = "Amerika"},
               new Country{Id = 3, Name = "Almanya"},
               new Country{Id = 5, Name = "Bayburtiye"}
            };

            City[] cities = new City[]
            {
                new City {Id = 58, Name = "Sivas", CountryId = 1},
                new City {Id = 6, Name = "Ankara", CountryId = 1},
                new City {Id = 888, Name = "New York", CountryId = 2},
                new City {Id = 34,  Name = "Munih", CountryId = 3},
                new City {Id = 34,  Name = "Bayburt", CountryId = 99},
            };

            var joinList = countries.GroupJoin(cities, cnt => cnt.Id, cty => cty.CountryId, (cnt, cty) => new
            {
                Ulke = cnt.Name,
                Sehirler = cty
            });
            foreach (var joinL in joinList)
            {
                Console.WriteLine($"Ülke: {joinL.Ulke}");
                Console.WriteLine($"Şehirler: ");
                foreach (var item in joinL.Sehirler)
                {
                    Console.WriteLine(item.Name);
                }
            }
        }


        #endregion
        #region GroupBy
        public void GroupBy()
        {
            int[] sayilar = new int[] { 1, 2, 3, 4, 5, 6 };
            var a = sayilar.GroupBy(x => (x % 2 == 0));
            foreach (var grup1 in a)
            {
                Console.WriteLine(grup1.Key);
                foreach (var grup2 in grup1)
                {
                    Console.WriteLine(grup2);
                }
            }
           
        }
        #endregion
        public void Except()
        {
            int[] sayilistesi1 = new int[] { 1, 2, 3, 5, 7, 8, 9 };
            int[] sayilistesi2 = new int[] { 2, 2, 3, 4, 6, 8, 9 };
            sayilistesi1.Except(sayilistesi2).ToList().ForEach(x => Console.WriteLine(x));
        }
   


    }
    class DataAccess
    {
        #region AddCar
        public List<Cars> cars = new List<Cars>();
        Cars car = new Cars() { name = "A", price = 50, speed = 100 };
        Cars car1 = new Cars() { name = "B", price = 100, speed = 200 };
        Cars car2 = new Cars() { name = "C", price = 150, speed = 300 };
        Cars car3 = new Cars() { name = "D", price = 200, speed = 400 };
        Cars car4 = new Cars() { name = "E", price = 200, speed = 5000 };


        
        public void AddCar()
        {

            cars.Add(car);
            cars.Add(car1);
            cars.Add(car2);
            cars.Add(car3);
            cars.Add(car4);
        }

        #endregion
    }


    class Cars
    {
        public int price { get; set; }
        public int speed { get; set; }
        public string name { get; set; }

    }
}