using System;
using System.Linq;
using System.Web.Mvc;
using HamburgerSiparis.DataAccessLayer.Context; 
namespace HamburgerSiparis.Web.Areas.Yonetim.Controllers
{
    public class SiparisController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();

        
        public ActionResult Index()
        {
            
            var siparisler = unitOfWork.SiparisRepository.Listele().OrderByDescending(x => x.SiparisTarihi).ToList();
            return View(siparisler);
        }

        
        public ActionResult DurumGuncelle(int id, string yeniDurum)
        {
            var siparis = unitOfWork.SiparisRepository.Bul(id);
            if (siparis != null)
            {
                siparis.Durum = yeniDurum;
                unitOfWork.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Tamamla(int id)
        {
            
            var siparis = unitOfWork.SiparisRepository.Bul(id);

            if (siparis != null)
            {
                
                siparis.Durum = "Teslim Edildi";

              
                unitOfWork.SiparisRepository.Guncelle(siparis);
                unitOfWork.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Iptal(int id)
        {
            var siparis = unitOfWork.SiparisRepository.Bul(id);

            if (siparis != null)
            {
                siparis.Durum = "İptal Edildi";

               
                unitOfWork.SiparisRepository.Guncelle(siparis);
                unitOfWork.SaveChanges();
            }

            return RedirectToAction("Index");
        }


    }
}