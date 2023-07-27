
using JsonProps;
using Newtonsoft.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace JsonExample
{
    internal class Program
    {


        static void Main(string[] args)
        {
            Business business = new Business();
            /*business.GetAll();
            Console.WriteLine();
            business.DeSeriealize();*/
            business.GetService();

            Console.ReadLine();
        }

    }

    public class Business
    {
        string json;
        List<Category> categories = new List<Category>()


        {
            new Category { Id = 1, Name = "mouse" , Products = new List<Product>()
               {
                    new Product() { Name = "xtrfy", Id = 20, HasStock = true, StockNumber = 5 },
                    new Product() { Name = "goSmart", Id = 23, HasStock = true, StockNumber = 9 },
               }
            },
            new Category { Id = 2, Name = "keyboard" , Products = new List<Product>()
                {
                    new Product() { Name = "razer", Id = 30, HasStock = true, StockNumber = 2 },
                    new Product() { Name = "hyperX", Id = 32, HasStock = true, StockNumber = 4 },
                }
            },
            new Category { Id = 3, Name = "monitor" , Products = new List<Product>()
                {
                    new Product() { Name = "benQ", Id = 40, HasStock = true, StockNumber = 1 },
                    new Product() { Name = "viewsonic", Id = 45, HasStock = false, StockNumber = 0 }
                }
            }
    };


        public void GetAll()
        {
            json = JsonConvert.SerializeObject(categories);
            Console.WriteLine(json);

        }
        public void DeSeriealize()
        {
            List<Category> deSeriealizedCategories = JsonConvert.DeserializeObject<List<Category>>(json);
            foreach (var category in deSeriealizedCategories)
            {
                Console.WriteLine(category);
                foreach (var product in category.Products)
                {
                    Console.WriteLine(product);
                }
            }
        }

        public void GetService()
        {
            string filePath = @"C:\Users\P2635\Desktop\JsonResult.txt";
            string fileContent = File.ReadAllText(filePath);

            Console.WriteLine(fileContent);
            Console.ReadLine();
            Console.WriteLine();

            List<Service> services = JsonConvert.DeserializeObject<List<Service>>(fileContent);
            foreach (var item in services)
            {
                Console.WriteLine(item);
            }

            string filePath2 = @"C:\Users\P2635\Desktop\sa.txt";
            string fileContent2 = File.ReadAllText(filePath2);
            ServiceList serviceList = JsonConvert.DeserializeObject<ServiceList>(fileContent2);    

            foreach (var item in serviceList.Services)
            {
                Console.WriteLine(item);
            }
            foreach (var item in serviceList.Services)
            {
                if (item.Port >= 5)
                {
                    var a = JsonConvert.SerializeObject(item);
                    File.WriteAllText(filePath2, a);
                }
            }

            Console.WriteLine(fileContent2);
        }
    }
}