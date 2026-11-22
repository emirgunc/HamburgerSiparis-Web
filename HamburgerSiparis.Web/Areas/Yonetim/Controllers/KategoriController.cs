using HamburgerSiparis.DataAccessLayer.Context;
using HamburgerSiparis.EntityLayer;
using HamburgerSiparis.Web.Filters;
using System.Web.Mvc;

namespace HamburgerSiparis.Web.Areas.Yonetim.Controllers
{
    
    [Kimlik]
    public class KategoriController : Controller
    {
        
        UnitOfWork unitOfWork = new UnitOfWork();
      
        public ActionResult Index()
        {
          
            var kategoriler = unitOfWork.KategoriRepository.Listele();
            return View(kategoriler);
        }

       
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult Ekle(Kategori data)
        {
            if (ModelState.IsValid) 
            {
                unitOfWork.KategoriRepository.Ekle(data);
                unitOfWork.SaveChanges(); 
                return RedirectToAction("Index"); 
            }
            return View(data); 
        }

        
        public ActionResult Sil(int id)
        {
            var silinecek = unitOfWork.KategoriRepository.Bul(id);
            if (silinecek != null)
            {
                unitOfWork.KategoriRepository.Sil(silinecek);
                unitOfWork.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public ActionResult Duzenle(int id)
        {
            var kategori = unitOfWork.KategoriRepository.Bul(id);
            if (kategori == null)
            {
                return HttpNotFound();
            }
            return View(kategori);
        }

        
        [HttpPost]
        public ActionResult Duzenle(Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.KategoriRepository.Guncelle(kategori);
                unitOfWork.SaveChanges(); 
                return RedirectToAction("Index");
            }
            return View(kategori);
        }








    }
}