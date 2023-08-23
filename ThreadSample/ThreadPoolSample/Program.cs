using System;
using System.Threading;
using System.Threading.Tasks;

public class Program
{
    static void Main()
    {
        for (int i = 0; i < 5; i++)
        {
            ThreadPool.QueueUserWorkItem(DoWork, i);
        }

        Console.ReadLine();
    }

    static void DoWork(object state)
    {
        int id = (int)state;
        Console.WriteLine("İş parçacığı {0} çalışıyor...", id);
        Thread.Sleep(2000);
        Console.WriteLine("İş parçacığı {0} tamamlandı.", id);
    }
}