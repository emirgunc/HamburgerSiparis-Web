using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HamburgerSiparis.EntityLayer
{
    [Table("Kullanicilar")]
    public class Kullanici
    {
        [Key]
        public int KullaniciId { get; set; }

        [Required(ErrorMessage = "Ad Soyad boş geçilemez!")]
        [StringLength(50)]
        public string AdSoyad { get; set; }

        [Required(ErrorMessage = "E-Posta boş geçilemez!")]
        [StringLength(50)]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre boş geçilemez!")]
        [StringLength(20)]
        public string Sifre { get; set; }

        [Required]
        public int Yetki { get; set; } 
    }
}