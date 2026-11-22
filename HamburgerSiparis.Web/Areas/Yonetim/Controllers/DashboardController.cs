using HamburgerSiparis.DataAccessLayer.Context;
using System.Linq;
using System.Web.Mvc;

namespace HamburgerSiparis.Web.Areas.Yonetim.Controllers
{
    [Authorize] 
    public class DashboardController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();

        public ActionResult Index()
        {
            
                      
            ViewBag.ToplamKazanc = unitOfWork.SiparisRepository.Listele().Sum(x => (decimal?)x.ToplamTutar) ?? 0;
            ViewBag.ToplamSiparis = unitOfWork.SiparisRepository.Listele().Count;

            ViewBag.UrunSayisi = unitOfWork.UrunRepository.Listele().Count;
            ViewBag.KategoriSayisi = unitOfWork.KategoriRepository.Listele().Count;

            return View();
        }
    }
}
