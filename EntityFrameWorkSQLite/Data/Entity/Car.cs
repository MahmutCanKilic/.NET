using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity
{
    public class Car
    {
        
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int speed { get; set; }
        public string CarType { get; set; }
        public Customer Customer { get; set; }

    }
}