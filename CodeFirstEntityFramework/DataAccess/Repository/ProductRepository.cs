using Data.NewFolder;
using DataAccess.Context;
using Org.BouncyCastle.Asn1.Cms;
using System.Diagnostics;

namespace DataAccess.Repository
{
    public class ProductRepository
    {
        MyContext db = new MyContext();
        private object lockObject = new object();
        public IEnumerable<Product> Find(Product product)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            IEnumerable<Product> result = null;
            lock (lockObject)
            {
                Thread thread = new Thread(() =>
                {
                    result = db.Products.Where(x => x.Id == product.Id || x.Name == product.Name);
                });
                thread.Start();
                thread.Join();
                stopwatch.Stop();

            }
            TimeSpan elapsed = stopwatch.Elapsed;
            Console.WriteLine($"Geçen süre: {elapsed.Hours:00}:{elapsed.Minutes:00}:{elapsed.Seconds:00}.{elapsed.Milliseconds:000}");
            return result;

        }
        public async Task Add(Product product)
        {
            await Task.Run(() =>
            {
                db.Products.Add(product);
                db.SaveChanges();
            });
        }
        public async Task Delete(Product product)
        {
            await Task.Run(() =>
            {
                db.Remove(Find(product));
                db.SaveChanges();
            });

        }
        public async Task UpdateAsync(Product product)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            await Task.Run(() =>
            {
                db.Attach(product);
                db.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            });
            TimeSpan elapsed = stopwatch.Elapsed;
            Console.WriteLine($"Async Geçen süre: {elapsed.Hours:00}:{elapsed.Minutes:00}:{elapsed.Seconds:00}.{elapsed.Milliseconds:000}");
        }
        public void UpdateSemaphore(Product product)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            Semaphore semaphore = new Semaphore(3, 3);
            for (int i = 0; i < 3; i++)
            {
                Thread thread = new Thread(ToDo);
                thread.Start();
            }

            void ToDo()
            {
                try
                {
                    db.Attach(product);
                    db.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    semaphore.WaitOne();
                }
                finally
                {
                    semaphore.Release();
                }
            }
            TimeSpan elapsed = stopwatch.Elapsed;
            Console.WriteLine($"3 Thread Geçen süre: {elapsed.Hours:00}:{elapsed.Minutes:00}:{elapsed.Seconds:00}.{elapsed.Milliseconds:000}");
        }
        public void UpdateOneThread(Product product)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            Thread thread = new Thread(() =>
            {
                db.Attach(product);
                db.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            });
            thread.Start();
            thread.Join();
            TimeSpan elapsed = stopwatch.Elapsed;
            Console.WriteLine($"1 Thread Geçen süre: {elapsed.Hours:00}:{elapsed.Minutes:00}:{elapsed.Seconds:00}.{elapsed.Milliseconds:000}");
        }

        public async Task<List<Product>> GetAll()
        {
            return await Task.Run(() =>
             {
                 return db.Products.ToList();
             });
        }
    }
}