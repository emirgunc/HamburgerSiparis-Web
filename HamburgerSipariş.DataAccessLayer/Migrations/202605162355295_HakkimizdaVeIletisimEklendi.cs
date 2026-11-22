namespace HamburgerSipariş.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HakkimizdaVeIletisimEklendi : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Iletisim");
            DropTable("dbo.Hakkimizda");
        }
    }
}
