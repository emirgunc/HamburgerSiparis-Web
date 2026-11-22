using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HamburgerSiparis.EntityLayer
{
    [Table("SiparisDetaylari")]
    public class SiparisDetay
    {
        [Key]
        public int SiparisDetayId { get; set; }

        public int SiparisId { get; set; }
        [ForeignKey("SiparisId")]
        public virtual Siparis Siparis { get; set; }

        public int UrunId { get; set; }
        [ForeignKey("UrunId")]
        public virtual Urun Urun { get; set; }

        public int Adet { get; set; }
        public decimal Fiyat { get; set; } 
        public string Ekstralar { get; set; } 
    }
}