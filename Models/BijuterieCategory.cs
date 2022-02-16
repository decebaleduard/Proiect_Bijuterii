using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_Bijuterii.Models
{
    public class BijuterieCategory
    {
        public int ID { get; set; }
        public int BijuterieID { get; set; }
        public Bijuterie Bijuterie { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }

    }
}
