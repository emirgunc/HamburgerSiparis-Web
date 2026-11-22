using HamburgerSiparis.DataAccessLayer.Context;
using HamburgerSiparis.EntityLayer;
using HamburgerSiparis.Web.Filters;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
namespace HamburgerSiparis.Web.Areas.Yonetim.Controllers
{
    [Kimlik] 
    public class UrunController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();

     
        public ActionResult Index()
        {
            var urunler = unitOfWork.UrunRepository.Listele();
            return View(urunler);
        }

      
        [HttpGet]
        public ActionResult Ekle()
        {
            
            var kategoriler = unitOfWork.KategoriRepository.Listele();
            ViewBag.KategoriListesi = new SelectList(kategoriler, "KategoriId", "KategoriAdi");
            ViewBag.KategoriId = new SelectList(unitOfWork.KategoriRepository.Listele(), "KategoriId", "KategoriAdi");
            return View();
        }


        [HttpPost]
        public ActionResult Ekle(Urun data, HttpPostedFileBase UrunResmi)
        {
            if (ModelState.IsValid)
            {
               
                if (UrunResmi != null && UrunResmi.ContentLength > 0)
                {
                    
                    string uzanti = Path.GetExtension(UrunResmi.FileName);

                    
                    string yeniResimAdi = Guid.NewGuid().ToString() + uzanti;

                   
                    string kayitYolu = Path.Combine(Server.MapPath("~/Images/"), yeniResimAdi);

                    
                    UrunResmi.SaveAs(kayitYolu);

                   
                    data.ResimYolu = "/Images/" + yeniResimAdi;
                }
                else
                {
                    
                    data.ResimYolu = "/Images/default-burger.png";
                }

               
                unitOfWork.UrunRepository.Ekle(data);
                unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

           
            var kategoriler = unitOfWork.KategoriRepository.Listele();
            ViewBag.KategoriListesi = new SelectList(kategoriler, "KategoriId", "KategoriAdi");
            ViewBag.KategoriId = new SelectList(unitOfWork.KategoriRepository.Listele(), "KategoriId", "KategoriAdi", data.KategoriId);
            return View(data);
        }

       
        public ActionResult Sil(int id)
        {
            var silinecek = unitOfWork.UrunRepository.Bul(id);
            if (silinecek != null)
            {
                unitOfWork.UrunRepository.Sil(silinecek);
                unitOfWork.SaveChanges();
            }
            return RedirectToAction("Index");
        }


      
        [HttpGet]
        public ActionResult Duzenle(int id)
        {
            var urun = unitOfWork.UrunRepository.Bul(id);
            ViewBag.KategoriId = new SelectList(unitOfWork.KategoriRepository.Listele(), "KategoriId", "KategoriAdi", urun.KategoriId);
            return View(urun);
        }

        
        [HttpPost]
        public ActionResult Duzenle(Urun data, HttpPostedFileBase YeniUrunResmi)
        {
            if (ModelState.IsValid)
            {
               
                if (YeniUrunResmi != null && YeniUrunResmi.ContentLength > 0)
                {
                    
                    string dosyaAdi = System.IO.Path.GetFileName(YeniUrunResmi.FileName);
                    string kayitYolu = Server.MapPath("~/Images/" + dosyaAdi);
                    YeniUrunResmi.SaveAs(kayitYolu);

                    
                    data.ResimYolu = "/Images/" + dosyaAdi;
                }
                

                unitOfWork.UrunRepository.Guncelle(data);
                unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            
            ViewBag.KategoriId = new SelectList(unitOfWork.KategoriRepository.Listele(), "KategoriId", "KategoriAdi", data.KategoriId);
            return View(data);
        }




    }
  }