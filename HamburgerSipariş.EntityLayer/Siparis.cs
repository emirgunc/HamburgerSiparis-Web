using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HamburgerSiparis.EntityLayer
{
    [Table("Siparisler")]
    public class Siparis
    {
        [Key]
        public int SiparisId { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public decimal ToplamTutar { get; set; }
        public string Durum { get; set; }

        
        public virtual ICollection<SiparisDetay> SiparisDetaylari { get; set; }

        public Siparis()
        {
            SiparisDetaylari = new HashSet<SiparisDetay>();
        }
    }
}
