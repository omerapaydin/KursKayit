using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kurs.Data
{
    public class KursKayit
    {
         [Key]
        public int KayitId { get; set; }
        public DateTime KayitTarihi{ get; set; }
        public int OgrenciId { get; set; }
        public Ogrenci Ogrenci { get; set; } =null!;
        public int KursId { get; set; }
        public Kurss Kurs { get; set; } = null!;

    }
}