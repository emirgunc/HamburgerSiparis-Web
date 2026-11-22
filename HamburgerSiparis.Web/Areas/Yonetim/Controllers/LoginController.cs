using HamburgerSiparis.DataAccessLayer.Context;
using HamburgerSiparis.EntityLayer;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace HamburgerSiparis.Web.Areas.Yonetim.Controllers
{
    public class LoginController : Controller
    {
      
        UnitOfWork unitOfWork = new UnitOfWork();

        
        [HttpGet]
        public ActionResult Index()
        {
            
            using (var db = new HamburgerSiparis.DataAccessLayer.Context.HamburgerContext())
            {
                var enesVarMi = db.Kullanicilar.FirstOrDefault(x => x.Email == "enes@golyakaburger.com");
                if (enesVarMi == null)
                {
                    HamburgerSiparis.EntityLayer.Kullanici yeniMudur = new HamburgerSiparis.EntityLayer.Kullanici();
                    yeniMudur.Email = "enes@golyakaburger.com";
                    yeniMudur.Sifre = "123456"; 
                    yeniMudur.Yetki = 2;
                    yeniMudur.AdSoyad = "Enes"; 

                    db.Kullanicilar.Add(yeniMudur);
                    db.SaveChanges(); 
                }
            }
            

            return View();
        }

        
        [HttpPost]
        public ActionResult Index(Kullanici k)
        {
           
            var dbalKullanici = unitOfWork.KullaniciRepository.Bul(x => x.Email == k.Email && x.Sifre == k.Sifre);

            if (dbalKullanici != null)
            {
                
                FormsAuthentication.SetAuthCookie(dbalKullanici.Email, false);

                
                Session["Yetki"] = dbalKullanici.Yetki;
                Session["AdSoyad"] = dbalKullanici.AdSoyad;

               
                return RedirectToAction("Index", "Dashboard", new { area = "Yonetim" });
            }
            else
            {
               
                ViewBag.Hata = "Kullanıcı adı veya parola hatalı!!!";
                return View();
            }
        }

       
        public ActionResult CikisYap()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}