using HamburgerSiparis.DataAccessLayer.Context;
using HamburgerSiparis.EntityLayer;
using HamburgerSiparis.Web.Filters;
using System.Web.Mvc;
using System.Linq;

namespace HamburgerSiparis.Web.Areas.Yonetim.Controllers
{
    
    [Kimlik]
    public class HakkimizdaController : Controller
    {
       
        UnitOfWork unitOfWork = new UnitOfWork();

       
        public ActionResult Index()
        {
            var hakkimizda = unitOfWork.HakkimizdaRepository.Listele().FirstOrDefault();

          
            if (hakkimizda == null)
            {
                var yeniKayit = new Hakkimizda { Baslik = "Lütfen Başlık Girin", Icerik = "Lütfen İçerik Girin" };
                unitOfWork.HakkimizdaRepository.Ekle(yeniKayit);
                unitOfWork.SaveChanges(); 

                hakkimizda = yeniKayit; 
            }

            return View(hakkimizda);
        }

       
        [HttpGet]
        public ActionResult Duzenle(int id)
        {
            var hakkimizda = unitOfWork.HakkimizdaRepository.Bul(id);
            if (hakkimizda == null)
            {
                return HttpNotFound();
            }
            return View(hakkimizda);
        }

      
        [HttpPost]
        public ActionResult Duzenle(Hakkimizda p)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.HakkimizdaRepository.Guncelle(p);
                unitOfWork.SaveChanges(); 
                return RedirectToAction("Index");
            }
            return View(p);
        }
    }
}