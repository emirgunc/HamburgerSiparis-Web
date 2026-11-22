using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HamburgerSiparis.EntityLayer
{
    [Table("Urunler")]
    public class Urun
    {
        [Key]
        public int UrunId { get; set; }

        [Required(ErrorMessage = "Ürün adı zorunludur!")]
        [StringLength(100)]
        public string UrunAdi { get; set; }

        [Required(ErrorMessage = "Fiyat zorunludur!")]
        public decimal Fiyat { get; set; }

        public string Aciklama { get; set; }

        public string ResimYolu { get; set; }

        public int KategoriId { get; set; }
        public virtual Kategori Kategori { get; set; }
    }
}



