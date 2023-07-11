using System.Collections;
using System.Collections.Generic;

namespace ExampleInterfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            People peopleList = new People();
            peopleList.AddPerson(new Person { Name = "Can", SurName = "Kılıç", Age = 24 });
            peopleList.AddPerson(new Person { Name = "Buğra", SurName = "Sizer", Age = 23 });
            peopleList.AddPerson(new Person { Name = "Yusuf", SurName = "Çifci", Age = 25 });

            foreach (var p in peopleList)
            
                Console.WriteLine();
            

                //Console.WriteLine(p.name + "  " + p.surname);
            Console.ReadKey();
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public int Age { get; set; }
    }

    public class People : IEnumerable
    {
        private List<Person> people;
        public People()
        {
            people = new List<Person>();
        }
        public void AddPerson(Person person)
        {
            people.Add(person);
        }

        public IEnumerator GetEnumerator()
        {
            return new MyEnumerator(people);
        }
    }

    public class MyEnumerator : IEnumerator
    {

        private List<Person> _peopleForIteration = new List<Person>();
        int position = -1;

       public MyEnumerator(List<Person> peopleForIteration)
        {
            _peopleForIteration = peopleForIteration;
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public Person Current
        {
            get
            {
                try
                {
                    return _peopleForIteration[position];
                }

                catch (IndexOutOfRangeException)
                {

                    throw new InvalidOperationException();
                }
            }
        }


        public bool MoveNext()
        {
            position++;
            Console.Write(position.ToString() + ". indexli nesne => ");
            return (position < _peopleForIteration.Count);
        }

        public void Reset() => position = -1;


    }
}