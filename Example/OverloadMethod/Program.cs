namespace EventHandlerExample_
{


    internal class Program
    {
        static event EventHandler myEventHandler;
        static void Main(string[] args)
        {
            myEventHandler += Program_myEventHandler;

            Kup kup = new Kup() { boy = 5, en = 5, yukseklik = 5, yazi = "bes" };

            KupInfo kupInfo = new KupInfo();
            kupInfo.kupIsim = "KÜP";

            myEventHandler(kup, kupInfo);

        }

        private static void Program_myEventHandler(object sender, EventArgs e)
        {
            
            Console.WriteLine("Bir kenarı: " + ((Kup)sender).en + "  Yazıyla: " + ((Kup)sender).yazi);
            Console.WriteLine("İsim: " + ((KupInfo)e).kupIsim);
            Console.ReadKey();
        }
    }

    class Kup
    {
        public int en;
        public int boy;
        public double yukseklik;
        public string yazi;
    }

    class KupInfo : EventArgs
    {
        public string kupIsim;
    }
}