using System.Diagnostics.Tracing;

namespace EventHandlerExample
{

    delegate void Test();


    internal class Program
    {
        public event Test x
        {
            add { Console.WriteLine("Metot eklendi"); }
            remove { Console.WriteLine("Metot kaldırıldı"); }
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.x += program.Deneme;
            program.x += program.Deneme2;


            /*Test y = program.x;
            y += Deneme2;
            y();
            y -= program.Deneme;*/

            Console.ReadLine();

        }

        public void Deneme2()
        {
            Console.WriteLine("Deneme2 Başarılı");
        }

        public void Deneme()
        {
            Console.WriteLine("Deneme Başarılı");
        }

    }

}