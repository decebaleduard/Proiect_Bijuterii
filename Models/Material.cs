using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_Bijuterii.Models
{
    public class Material
    {public int ID { get; set; }
        public string DenumireMaterial { get; set; }
        public ICollection<Bijuterie> Bijuterii { get; set; }
    }
}
