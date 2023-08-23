using System;
using System.Threading;

public class Program
{
    private static object lockObject = new object(); // Senkronizasyon için kullanılacak kilitleme nesnesi

    static void Main()
    {
        Thread thread1 = new Thread(DoWork);
        Thread thread2 = new Thread(DoWork);
        thread1.IsBackground = true;
        thread2.IsBackground = true;
        thread1.Start();
        thread2.Start();
        
        DoWork();
        thread2.Join();
    }

    static void DoWork()
    {
        // lock ifadesi içindeki kod bloğu sadece bir iş parçacığı tarafından aynı anda çalıştırılabilir
        lock (lockObject)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"İş parçacığı {Thread.CurrentThread.ManagedThreadId} çalışıyor... Adım: {i}");
                Thread.Sleep(500);
            }
        }
    }
}
