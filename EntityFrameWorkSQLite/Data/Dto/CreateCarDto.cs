using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dto
{
    public class CreateCarDto
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int speed { get; set; }
        public string CarType { get; set; }
    }
}
