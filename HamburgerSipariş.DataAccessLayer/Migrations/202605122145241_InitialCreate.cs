namespace HamburgerSipariş.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kategoriler",
                c => new
                    {
                        KategoriId = c.Int(nullable: false, identity: true),
                        KategoriAdi = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.KategoriId);
            
            CreateTable(
                "dbo.Urunler",
                c => new
                    {
                        UrunId = c.Int(nullable: false, identity: true),
                        UrunAdi = c.String(nullable: false, maxLength: 100),
                        Fiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Aciklama = c.String(),
                        ResimYolu = c.String(),
                        KategoriId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UrunId)
                .ForeignKey("dbo.Kategoriler", t => t.KategoriId, cascadeDelete: true)
                .Index(t => t.KategoriId);
            
            CreateTable(
                "dbo.Kullanicilar",
                c => new
                    {
                        KullaniciId = c.Int(nullable: false, identity: true),
                        AdSoyad = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Sifre = c.String(nullable: false, maxLength: 20),
                        Yetki = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KullaniciId);
            
            CreateTable(
                "dbo.Siparisler",
                c => new
                    {
                        SiparisId = c.Int(nullable: false, identity: true),
                        SiparisTarihi = c.DateTime(nullable: false),
                        ToplamTutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SiparisDetayi = c.String(),
                        Durum = c.String(),
                    })
                .PrimaryKey(t => t.SiparisId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Urunler", "KategoriId", "dbo.Kategoriler");
            DropIndex("dbo.Urunler", new[] { "KategoriId" });
            DropTable("dbo.Siparisler");
            DropTable("dbo.Kullanicilar");
            DropTable("dbo.Urunler");
            DropTable("dbo.Kategoriler");
        }
    }
}
