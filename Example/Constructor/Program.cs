namespace Constructor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo cki;
            /*do
            {
                ConsoleKeyInfo consoleKeyInfo;
                consoleKeyInfo = Console.ReadKey(true);
                Console.WriteLine(Convert.ToInt64(consoleKeyInfo.KeyChar));
                cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.F1)
                {
                    Environment.Exit(0);
                }
            } while (cki.Key != ConsoleKey.F1);*/




            int i = 0;




            //do
            //{
            //    cki = Console.ReadKey();
            //    if (cki.Key == ConsoleKey.F1)
            //    {
            //        Environment.Exit(0);
            //    }

            //    else if (cki.Key == ConsoleKey.Enter && i < 11)
            //    {
            //        ConstructorLoop loop = new ConstructorLoop();
            //        i++;
            //    }
            //} while (cki.Key != ConsoleKey.F1 && i < 11);
            do
            {
                cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.F1)
                {
                    Environment.Exit(0);
                }

                else if (cki.Key == ConsoleKey.Enter)
                {
                    ConstructorLoop loop = new ConstructorLoop();
                    i++;
                }
            } while (i < 11);
            Console.WriteLine("Test");


        }

        //her enter a bastıgında yeni bir product oluştur().  datetime
    }
    class ConstructorLoop
    {

        public ConstructorLoop()
        {
            Product();
        }
        public void Product()
        {

            Console.WriteLine(DateTime.Now);
        }
    }
}