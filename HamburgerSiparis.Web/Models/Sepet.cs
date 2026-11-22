using HamburgerSiparis.EntityLayer;
using System.Collections.Generic;
using System.Linq;

namespace HamburgerSiparis.Web.Models
{
    
    public class SepetElemani
    {
        public Urun Urun { get; set; }
        public int Adet { get; set; }
        public decimal GuncelFiyat { get; set; } 
        public string Ekstralar { get; set; } 
    }

   
    public class Sepet
    {
        private List<SepetElemani> _sepetLine = new List<SepetElemani>();
        public List<SepetElemani> SepetLine { get { return _sepetLine; } }

        
        public void UrunEkle(Urun urun, int adet, decimal guncelFiyat, string ekstralar)
        {
            _sepetLine.Add(new SepetElemani
            {
                Urun = urun,
                Adet = adet,
                GuncelFiyat = guncelFiyat,
                Ekstralar = ekstralar
            });
        }

        
        public void Temizle()
        {
            _sepetLine.Clear();
        }

        
        public decimal ToplamTutar()
        {
            return _sepetLine.Sum(x => x.GuncelFiyat * x.Adet);
        }
    }
}