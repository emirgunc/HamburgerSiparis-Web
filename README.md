# HamburgerSipariş.Web

ASP.NET MVC (.NET Framework) ve çok katmanlı mimari kullanılarak geliştirilmiş hamburger sipariş ve sepet yönetimi web uygulaması.

## Mimari Yapı

- **HamburgerSipariş.EntityLayer:** Veritabanı varlık modelleri
- **HamburgerSipariş.DataAccessLayer:** `Context`, `Migrations` ve veri erişim katmanı
- **HamburgerSiparis.Web:** MVC Controller'lar (`HomeController`, `SepetController`, `SiparisController`), `Filters`, `Roller`, `Areas` ve Razor View'lar

## Kurulum

1. `HamburgerSiparis.Web.sln` dosyasını Visual Studio ile açın.
2. NuGet paketlerini geri yükleyin (Restore NuGet Packages).
3. `Web.config` içindeki veritabanı bağlantı dizesini kendi yerel SQL Server / LocalDB ortamınıza göre güncelleyin ve Entity Framework migration'larını çalıştırın.
4. `F5` ile projeyi başlatın.
