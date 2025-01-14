using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kurs.Data
{
    public class Ogretmen
    {
            [Key]
        public int OgretmenId { get; set; }
        public string? Ad { get; set; }
        public string? Soyad { get; set; }
         public string AdSoyad { 
            get
            {
                return this.Ad + " " + this.Soyad;
            }
            
             }
        public string? Eposta { get; set; }
        public string? Telefon { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime BaslamaTarih { get; set; }

        public ICollection<Kurss> Kurslar { get; set; } = new List<Kurss>();
    }
}