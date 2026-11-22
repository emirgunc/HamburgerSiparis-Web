namespace HamburgerSipariş.DataAccessLayer.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Guncelleme1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Hakkimizda", "ResimUrl");
            DropColumn("dbo.Iletisim", "FacebookUrl");
            DropColumn("dbo.Iletisim", "InstagramUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Iletisim", "InstagramUrl", c => c.String());
            AddColumn("dbo.Iletisim", "FacebookUrl", c => c.String());
            AddColumn("dbo.Hakkimizda", "ResimUrl", c => c.String());
        }
    }
}
