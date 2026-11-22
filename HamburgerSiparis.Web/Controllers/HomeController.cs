using HamburgerSiparis.DataAccessLayer.Context;
using System.Linq;
using System.Web.Mvc;

namespace HamburgerSiparis.Web.Controllers
{
    public class HomeController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();

       
        public ActionResult Index(int? id)
        {
          
            ViewBag.Kategoriler = unitOfWork.KategoriRepository.Listele();

            
            var vitrinUrunleri = unitOfWork.UrunRepository.Listele();

           
            if (id != null)
            {
                vitrinUrunleri = vitrinUrunleri.Where(x => x.KategoriId == id).ToList();
            }

            return View(vitrinUrunleri);
        }


        
        public ActionResult Hakkimizda()
        {
            var hakkimizda = unitOfWork.HakkimizdaRepository.Listele().FirstOrDefault();
            return View(hakkimizda);
        }

       
        public ActionResult Iletisim()
        {
            var iletisimBilgileri = unitOfWork.IletisimRepository.Listele();
            return View(iletisimBilgileri);
        }
    }
}