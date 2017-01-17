namespace HWHCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SelectionStrings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GasReciepts", "DateOnReciept", c => c.DateTime(nullable: false));
            AddColumn("dbo.Payments", "PaymentRecievedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Payments", "PaymentRecievedDate");
            DropColumn("dbo.GasReciepts", "DateOnReciept");
        }
    }
}
