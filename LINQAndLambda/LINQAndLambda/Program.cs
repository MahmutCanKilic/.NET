using System.Collections;
using System.Linq;

namespace LINQAndLambda
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Linq linq = new Linq();
            foreach (var item in linq.Where())
            {
                Console.WriteLine(item);
            }
            foreach (var item in linq.OrderBy())
            {
                Console.WriteLine(item);
            }
        }


    }
    class Linq
    {
        public IEnumerable numbers;
        Properties props = new Properties();

        public IEnumerable Where()
        {
            numbers = props.sayilar1.Where(x => x >= 3);
            return numbers;
        }
        public IEnumerable OrderBy()
        {
            numbers = props.sayilar1.Where(x => x >= 3).OrderByDescending(x => x);
            return numbers;
        }
        public int Sum()
        {
            int toplam = props.sayilar2.Sum();
            return toplam;
            props.sayilar2.
        }
    }
    class Properties
    {
        public int[] sayilar1 = new int[] { 1, 2, 3, 4, 5 };
        public int[] sayilar2 = new int[] { 1, 3, 5, 7, 7 };
        public string[] renkler = new string[] { "beyaz", "mor" };
    }
}