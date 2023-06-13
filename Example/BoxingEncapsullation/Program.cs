namespace BoxingEncapsullation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductManager a = new ProductManager();
            a.Product();

        }
        //product yazdırma metodu, isim, fiyat, stok miktarı,boş girilirse null

    }
    class ProductManager
    {
        public ProductManager()
        {
            Console.WriteLine("ProductManager oluşturuldu.");
        }
        private string name;
        private int cost, stock;

        public string Name
        {
            get { return name; }
            set
            {
                if (value != "")
                {
                    name = value;
                }
                else
                {
                    name = "Empty";
                }
            }
        }
        public int Cost
        {
            get { return cost; }
            set
            {
                if (value <= 0)
                {
                    cost = 0;
                }
                else
                {
                    cost = value;
                }
            }
        }
        public int Stock
        {
            get { return stock; }
            set
            {
                if (value <= 0 || value == null)
                {
                    stock = 0;
                }
                else
                {
                    stock = value;
                }
            }

        }
        public void Product()
        {
            Console.WriteLine("Name: ");
            Name = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Cost: ");
            Cost = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Stock: ");
            Stock = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Product Name: " + Name);
            Console.WriteLine("Product Cost: " + Cost);
            Console.WriteLine("Product Stock: " + Stock);
        }
    }
}