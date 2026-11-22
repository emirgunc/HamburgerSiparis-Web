  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;

    namespace HamburgerSiparis.EntityLayer 
{
    [Table("Kategoriler")]
    public class Kategori
    {
        [Key]
        public int KategoriId { get; set; }
       
      
        [Required(ErrorMessage = "Kategori adı boş geçilemez!")]
        [StringLength(50, ErrorMessage = "Kategori adı en fazla 50 karakter olabilir.")]
        public string KategoriAdi { get; set; }

       
        public virtual List<Urun> Urunler { get; set; }

        public Kategori()
        {
            Urunler = new List<Urun>();
        }
    }
}