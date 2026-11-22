namespace HamburgerSipariş.DataAccessLayer.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HamburgerSiparis.DataAccessLayer.Context.HamburgerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DataAccessLayer\Migrations";
        }

        protected override void Seed(HamburgerSiparis.DataAccessLayer.Context.HamburgerContext context)
        {
            // 1. Admin Kullanıcısını Ekle (Eğer yoksa ekle ki hata vermesin)
            if (!context.Kullanicilar.Any(x => x.Email == "emir@golyakaburger.com"))
            {
                context.Kullanicilar.Add(new HamburgerSiparis.EntityLayer.Kullanici()
                {
                    AdSoyad = "Emir",
                    Email = "emir@golyakaburger.com",
                    Sifre = "123456",
                    Yetki = 1 // Admin yetkisi
                });
            }

            // 2. 5 Ana Kategoriyi Ekle
            if (!context.Kategoriler.Any())
            {
                context.Kategoriler.Add(new HamburgerSiparis.EntityLayer.Kategori() { KategoriAdi = "Efsane Burgerler" });
                context.Kategoriler.Add(new HamburgerSiparis.EntityLayer.Kategori() { KategoriAdi = "İçecekler" });
                context.Kategoriler.Add(new HamburgerSiparis.EntityLayer.Kategori() { KategoriAdi = "Atıştırmalıklar" });
                context.Kategoriler.Add(new HamburgerSiparis.EntityLayer.Kategori() { KategoriAdi = "Menüler" });
                context.Kategoriler.Add(new HamburgerSiparis.EntityLayer.Kategori() { KategoriAdi = "Soslar" });
            }

            context.SaveChanges();
        }
    }
}
