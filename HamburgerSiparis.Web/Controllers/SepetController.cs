using HamburgerSiparis.DataAccessLayer.Context;
using HamburgerSiparis.Web.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace HamburgerSiparis.Web.Controllers
{
    public class SepetController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();

        
        public Sepet GetSepet()
        {
            var sepet = (Sepet)Session["Sepet"];
            if (sepet == null)
            {
                sepet = new Sepet();
                Session["Sepet"] = sepet;
            }
            return sepet;
        }

     
        [HttpPost]
        public JsonResult SepeteEkleAjax(int id, decimal fiyat, string ekstralar)
        {
            var urun = unitOfWork.UrunRepository.Bul(id);
            if (urun != null)
            {
                GetSepet().UrunEkle(urun, 1, fiyat, ekstralar);

               
                int toplamAdet = GetSepet().SepetLine.Sum(x => x.Adet);

                return Json(new { basarili = true, sayi = toplamAdet, mesaj = urun.UrunAdi + " sepete eklendi!" });
            }
            return Json(new { basarili = false, mesaj = "Ürün bulunamadı!" });
        }

        
        public ActionResult Index()
        {
           
            var sepet = GetSepet();

            
            return View(sepet);
        }

        [HttpPost]
        public JsonResult AdetGuncelleAjax(int index, int degisim)
        {
            var sepet = GetSepet();
            if (index >= 0 && index < sepet.SepetLine.Count)
            {
                var urunElemani = sepet.SepetLine[index];
                urunElemani.Adet += degisim;

                if (urunElemani.Adet <= 0)
                {
                    sepet.SepetLine.RemoveAt(index);
                    return Json(new
                    {
                        basarili = true,
                        sepetBosMu = sepet.SepetLine.Count == 0,
                        yeniToplam = sepet.ToplamTutar().ToString("N2"),
                        sayi = sepet.SepetLine.Sum(x => x.Adet) 
                    });
                }

                string satirToplami = (urunElemani.GuncelFiyat * urunElemani.Adet).ToString("N2");

                return Json(new
                {
                    basarili = true,
                    yeniToplam = sepet.ToplamTutar().ToString("N2"),
                    yeniSatirToplami = satirToplami,
                    sepetBosMu = false,
                    sayi = sepet.SepetLine.Sum(x => x.Adet) 
                });
            }
            return Json(new { basarili = false });
        }
        [HttpPost]
       
        public JsonResult SiparisiTamamlaAjax()
        {
            var sepet = GetSepet();

            
            if (sepet.SepetLine.Count == 0) return Json(new { basarili = false });

          
            HamburgerSiparis.EntityLayer.Siparis yeniSiparis = new HamburgerSiparis.EntityLayer.Siparis();
            yeniSiparis.SiparisTarihi = DateTime.Now;
            yeniSiparis.ToplamTutar = sepet.ToplamTutar();
            yeniSiparis.Durum = "Hazırlanıyor";

            
            foreach (var item in sepet.SepetLine)
            {
                HamburgerSiparis.EntityLayer.SiparisDetay detay = new HamburgerSiparis.EntityLayer.SiparisDetay();
                detay.UrunId = item.Urun.UrunId; 
                detay.Adet = item.Adet;
                detay.Fiyat = item.GuncelFiyat;
                detay.Ekstralar = item.Ekstralar;

                yeniSiparis.SiparisDetaylari.Add(detay); 
            }

           
            unitOfWork.SiparisRepository.Ekle(yeniSiparis);
            unitOfWork.SaveChanges();

           
            Session.Remove("Sepet");

            return Json(new { basarili = true });
        }

    }
}
