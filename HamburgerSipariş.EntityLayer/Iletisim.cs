using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HamburgerSiparis.EntityLayer
{
    [Table("Iletisim")]
    public class Iletisim
    {
        [Key]
        public int IletisimId { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
       
    }
}