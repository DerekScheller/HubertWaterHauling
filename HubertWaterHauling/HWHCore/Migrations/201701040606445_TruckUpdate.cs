namespace HWHCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TruckUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WaterTrucks", "Make", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WaterTrucks", "Make");
        }
    }
}
