using HamburgerSiparis.DataAccessLayer.Context;
using HamburgerSiparis.EntityLayer;
using HamburgerSiparis.Web.Filters; 
using System.Web.Mvc;

namespace HamburgerSiparis.Web.Areas.Yonetim.Controllers
{
    [Kimlik] 
    public class IletisimController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();

     
        public ActionResult Index()
        {
            var iletisimListesi = unitOfWork.IletisimRepository.Listele();
            return View(iletisimListesi);
        }

     
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Iletisim i)
        {
            unitOfWork.IletisimRepository.Ekle(i);
            unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

       
        [HttpGet]
        public ActionResult Duzenle(int id)
        {
            var iletisim = unitOfWork.IletisimRepository.Bul(id);
            return View(iletisim);
        }

        [HttpPost]
        public ActionResult Duzenle(Iletisim i)
        {
            unitOfWork.IletisimRepository.Guncelle(i);
            unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

       
        public ActionResult Sil(int id)
        {
            var iletisim = unitOfWork.IletisimRepository.Bul(id);
            unitOfWork.IletisimRepository.Sil(iletisim);
            unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}