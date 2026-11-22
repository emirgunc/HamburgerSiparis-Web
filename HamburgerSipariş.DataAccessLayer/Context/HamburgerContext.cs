using HamburgerSiparis.EntityLayer;
using System.Data.Entity;
namespace HamburgerSiparis.DataAccessLayer.Context
{
    public class HamburgerContext : DbContext
    {
        public HamburgerContext() : base("HamburgerConnection")
        {
            
            Database.SetInitializer(new MyDatabaseInitializer());
        }
        public DbSet<Hakkimizda> Hakkimizdalar { get; set; }
        public DbSet<Iletisim> Iletisimler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }
    }

   
    public class MyDatabaseInitializer : CreateDatabaseIfNotExists<HamburgerContext>
    {
        protected override void Seed(HamburgerContext context)
        {
            
            context.Kullanicilar.Add(new Kullanici()
            {
                AdSoyad = "Emir",
                Email = "emir@golyakaburger.com",
                Sifre = "123456",
                Yetki = 1 
            });

          
            var kat1 = new Kategori() { KategoriAdi = "Efsane Burgerler" };
            var kat2 = new Kategori() { KategoriAdi = "İçecekler" };
            context.Kategoriler.Add(kat1);
            context.Kategoriler.Add(kat2);

            
            context.Urunler.Add(new Urun() { UrunAdi = "Double Cheddar Burger", Fiyat = 250, Aciklama = "Çift köfte, çift cheddar", Kategori = kat1 });
            context.Urunler.Add(new Urun() { UrunAdi = "Buz Gibi Kola (1L)", Fiyat = 60, Aciklama = "Buzdolabı soğukluğunda", Kategori = kat2 });

            context.SaveChanges();
            base.Seed(context);
        }
    }
}