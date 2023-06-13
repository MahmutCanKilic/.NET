namespace Delegates
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            EkrandaGoster(123);
            var action = new Action<int>(EkrandaGoster);
            action(123);
            // Ekranda "123" gösterir
            // Ayrıca action.Invoke(123);
            // ile de çağırılabilir

            var func = new Func<int,int, double>(Hesapla);
            Console.WriteLine(func(5,6));
            // Ekranda "2.5" gösterir
        }

        public static void EkrandaGoster(int i)
        {
            Console.WriteLine(i);
        }

        public static double Hesapla(int i, int j)
        {
            return (double)i / j;
        }
    }
}