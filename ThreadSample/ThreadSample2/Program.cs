using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Thread myThread = new Thread(MyThreadFunction);
        myThread.Start();

        myThread.Join(); // Ana programın, thread'in tamamlanmasını beklemesi sağlanıyor.

        Console.WriteLine("Thread tamamlandı. Ana program devam ediyor.");
    }

    static void MyThreadFunction()
    {
        Console.WriteLine("Thread çalışıyor.");
        Thread.Sleep(3000);
        Console.WriteLine("Thread tamamlandı.");
    }
}
