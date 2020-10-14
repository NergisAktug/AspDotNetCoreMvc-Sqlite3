using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeCore.Models
{
    public class Birim
    {
        [Key]
        public int BirimId { get; set; }
        public string BirimAd { get; set; }
        //iliskiye aldıgımız alanı IList adinda interfacese aliyoruz.Class isimleri mutlaka buyuk olmali
        public IList<Personel> Personels { get; set; }
    }
}
