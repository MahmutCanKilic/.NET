namespace InterfaceExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sinif sinif = new Sinif();
            Console.WriteLine(sinif.AIArayuz(5));
            Console.WriteLine(sinif.BIArayuz(5));
            
        }
    }
    public interface IArayuz
    {
        int SayHello(int x);


    }
    public interface IArayuz2
    {
        int SayHello(int x);


    }
    public class Sinif : IArayuz, IArayuz2
    {
        int IArayuz.SayHello(int x)
        {
            return x + x;
        }

        int IArayuz2.SayHello(int x)
        {
            return x * x;
        }
        public int AIArayuz(int a)
        {
            IArayuz arayuz1 = this;
            return arayuz1.SayHello(a);
        }
        public int BIArayuz(int a)
        {
            IArayuz2 arayuz2 = this;
            return arayuz2.SayHello(a);
        }
    }
}
