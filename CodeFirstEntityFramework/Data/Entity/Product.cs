using Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Data.NewFolder
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual Category Categories { get; set; }
        public int CategoryId { get; set; }
        
    }
}