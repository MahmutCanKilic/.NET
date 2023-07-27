using Data.NewFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
    public class Category
    {
        public int Id { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public string CategoryName { get; set; }
        public int Description { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} | CategoryName: {CategoryName} | Description: {Description}";
        }

    }
}
