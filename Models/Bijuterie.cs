using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect_Bijuterii.Models
{
    public class Bijuterie
    {
        public int ID { get; set; }
        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Tipul Bijuteriei")]
        public string Tip { get; set; }
        [Required, StringLength(50, MinimumLength = 3)]
        [Display(Name = "Brand")]
        public string Marca { get; set; }
        [Column(TypeName ="decimal(6,2)")]
        [Range(1, 9000)]
        public decimal Pret { get; set; }
        public int MaterialID { get; set; }
        public Material Material { get; set; }
        public ICollection<BijuterieCategory> BijuterieCategories { get; set; }



    }
}
