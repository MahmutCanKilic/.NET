using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DbSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DbName { get; set; } = null!;
        public string ProductsCollectionName { get; set; } = null!;
    }
}
