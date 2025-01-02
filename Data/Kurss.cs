using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kurs.Data
{
    public class Kurss
    {
        [Key]
         public int KursId { get; set; }
        public string? Baslik { get; set; }

         public ICollection<KursKayit> KursKayitlari { get; set; } = new List<KursKayit>();
        public int OgretmenId { get; set; }
        public Ogretmen? Ogretmen { get; set; } = null!;
    }
}