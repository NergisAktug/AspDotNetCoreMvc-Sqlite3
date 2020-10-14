using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeCore.Models
{
    public class Personel
    {
        [Key]
        public int PersonelID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Sehir { get; set; }
        public int BirimId { get; set; }
        //birim sinifindan Birim adında bir property olusturdum.Veri tabanı iliskileri icin
        //Bir kisinin birden fazla birimi olabilir
        public Birim Birim { get; set; }

    }
}
