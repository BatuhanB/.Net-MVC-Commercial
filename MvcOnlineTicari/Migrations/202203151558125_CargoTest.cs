namespace MvcOnlineTicari.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CargoTest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CargoDetails",
                c => new
                    {
                        CargoDetailID = c.Int(nullable: false, identity: true),
                        CargoDetailDesc = c.String(maxLength: 300, unicode: false),
                        CargoDetailTrackCode = c.String(maxLength: 10, unicode: false),
                        CargoDetailEmployee = c.String(maxLength: 20, unicode: false),
                        CargoDetailReceiver = c.String(maxLength: 20, unicode: false),
                        CargoDetailDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CargoDetailID);
            
            CreateTable(
                "dbo.CargoTracks",
                c => new
                    {
                        CargoTrackID = c.Int(nullable: false, identity: true),
                        CargoTrackCode = c.String(maxLength: 10, unicode: false),
                        CargoTrackDesc = c.String(maxLength: 100, unicode: false),
                        CargoTrackDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CargoTrackID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CargoTracks");
            DropTable("dbo.CargoDetails");
        }
    }
}
