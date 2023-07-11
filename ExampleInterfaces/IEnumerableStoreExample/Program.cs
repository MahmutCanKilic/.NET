using System.Collections;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;

namespace IEnumerableStoreExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Store store = new Store();
            store.AddProduct(new Product { Name = "mouse", Piece = 3, Price = 300 });
            store.AddProduct(new Product { Name = "keyboard", Piece = 5, Price = 500 });
            foreach (var product in store.products)
            {
                Console.WriteLine(product.Name + "  " + product.Price);
                


            }
            Console.WriteLine(store.TotalPrice());
            Console.ReadKey();
            
        }

    }

    public class Store : IEnumerable
    {
        public List<Product> products;
        public Store()
        {
            products = new List<Product>();
        }


        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public int TotalPrice()
        {
            int total = 0;
            for (int i = 0; i < products.Count; i++)
            {
                total += products[i].Price * products[i].Piece;
            }
            return total;
        }
        public IEnumerator GetEnumerator()
        {
            return new MyEnumerator(products);
        }
    }
    public class Product
    {
        public string Name { get; set; }
        public int Piece { get; set; }
        public int Price { get; set; }
    }
    public class MyEnumerator : IEnumerator
    {
        List<Product> productList;
        int position = -1;
        object IEnumerator.Current
        {
            get { return Current; }
        }
        public MyEnumerator(List<Product> products)
        {
            productList = products;
        }
        public Product Current
        {
            get
            {
                try
                {
                    Console.WriteLine(1);
                    return productList[position];
                }
                catch (IndexOutOfRangeException)
                {

                    throw new InvalidOperationException();
                }
            }
        }
        public bool MoveNext()
        {
            Console.WriteLine(2);
            position++;
            return productList.Count > position;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}