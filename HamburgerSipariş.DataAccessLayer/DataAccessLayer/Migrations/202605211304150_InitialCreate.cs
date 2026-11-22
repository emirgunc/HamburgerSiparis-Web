namespace HamburgerSipariş.DataAccessLayer.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hakkimizda",
                c => new
                    {
                        HakkimizdaId = c.Int(nullable: false, identity: true),
                        Baslik = c.String(),
                        Icerik = c.String(),
                        ResimUrl = c.String(),
                    })
                .PrimaryKey(t => t.HakkimizdaId);
            
            CreateTable(
                "dbo.Iletisim",
                c => new
                    {
                        IletisimId = c.Int(nullable: false, identity: true),
                        Adres = c.String(),
                        Telefon = c.String(),
                        Email = c.String(),
                        FacebookUrl = c.String(),
                        InstagramUrl = c.String(),
                    })
                .PrimaryKey(t => t.IletisimId);
            
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
                        Durum = c.String(),
                    })
                .PrimaryKey(t => t.SiparisId);
            
            CreateTable(
                "dbo.SiparisDetaylari",
                c => new
                    {
                        SiparisDetayId = c.Int(nullable: false, identity: true),
                        SiparisId = c.Int(nullable: false),
                        UrunId = c.Int(nullable: false),
                        Adet = c.Int(nullable: false),
                        Fiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Ekstralar = c.String(),
                    })
                .PrimaryKey(t => t.SiparisDetayId)
                .ForeignKey("dbo.Siparisler", t => t.SiparisId, cascadeDelete: true)
                .ForeignKey("dbo.Urunler", t => t.UrunId, cascadeDelete: true)
                .Index(t => t.SiparisId)
                .Index(t => t.UrunId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SiparisDetaylari", "UrunId", "dbo.Urunler");
            DropForeignKey("dbo.SiparisDetaylari", "SiparisId", "dbo.Siparisler");
            DropForeignKey("dbo.Urunler", "KategoriId", "dbo.Kategoriler");
            DropIndex("dbo.SiparisDetaylari", new[] { "UrunId" });
            DropIndex("dbo.SiparisDetaylari", new[] { "SiparisId" });
            DropIndex("dbo.Urunler", new[] { "KategoriId" });
            DropTable("dbo.SiparisDetaylari");
            DropTable("dbo.Siparisler");
            DropTable("dbo.Kullanicilar");
            DropTable("dbo.Urunler");
            DropTable("dbo.Kategoriler");
            DropTable("dbo.Iletisim");
            DropTable("dbo.Hakkimizda");
        }
    }
}
