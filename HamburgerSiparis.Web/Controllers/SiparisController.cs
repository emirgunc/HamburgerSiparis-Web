using HamburgerSiparis.DataAccessLayer.Context;
using System.Web.Mvc;
using System.Linq;
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
}