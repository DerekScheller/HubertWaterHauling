namespace HWHCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NoBillNeeded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Payments", "BillId", "dbo.Bills");
            DropForeignKey("dbo.Bills", "TruckId", "dbo.WaterTrucks");
            DropForeignKey("dbo.Sales", "BillId", "dbo.Bills");
            DropForeignKey("dbo.Payments", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Sales", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.GasReciepts", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Sales", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.GasReciepts", "TruckId", "dbo.WaterTrucks");
            DropIndex("dbo.Bills", new[] { "TruckId" });
            DropIndex("dbo.Payments", new[] { "BillId" });
            DropIndex("dbo.Sales", new[] { "BillId" });
            AddColumn("dbo.Payments", "SaleId", c => c.Int(nullable: false));
            AddColumn("dbo.Sales", "PriceOfWater", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Sales", "LoadVolume", c => c.Int(nullable: false));
            AddColumn("dbo.Sales", "NumberOfLoads", c => c.Int(nullable: false));
            AddColumn("dbo.Sales", "PriceNet", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Sales", "GrossAmount", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Sales", "TruckId", c => c.Int(nullable: false));
            CreateIndex("dbo.Sales", "TruckId");
            CreateIndex("dbo.Payments", "SaleId");
            AddForeignKey("dbo.Payments", "SaleId", "dbo.Sales", "Id");
            AddForeignKey("dbo.Sales", "TruckId", "dbo.WaterTrucks", "Id");
            AddForeignKey("dbo.Payments", "CustomerId", "dbo.Customers", "Id");
            AddForeignKey("dbo.Sales", "CustomerId", "dbo.Customers", "Id");
            AddForeignKey("dbo.GasReciepts", "EmployeeId", "dbo.Employees", "Id");
            AddForeignKey("dbo.Sales", "EmployeeId", "dbo.Employees", "Id");
            AddForeignKey("dbo.GasReciepts", "TruckId", "dbo.WaterTrucks", "Id");
            DropColumn("dbo.Payments", "BillId");
            DropColumn("dbo.Sales", "BillId");
            DropTable("dbo.Bills");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PriceOfWater = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LoadVolume = c.Int(nullable: false),
                        NumberOfLoads = c.Int(nullable: false),
                        PriceNet = c.Decimal(precision: 18, scale: 2),
                        GrossAmount = c.Decimal(precision: 18, scale: 2),
                        DriverRetainagePercent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TruckId = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Sales", "BillId", c => c.Int(nullable: false));
            AddColumn("dbo.Payments", "BillId", c => c.Int(nullable: false));
            DropForeignKey("dbo.GasReciepts", "TruckId", "dbo.WaterTrucks");
            DropForeignKey("dbo.Sales", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.GasReciepts", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Sales", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Payments", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Sales", "TruckId", "dbo.WaterTrucks");
            DropForeignKey("dbo.Payments", "SaleId", "dbo.Sales");
            DropIndex("dbo.Payments", new[] { "SaleId" });
            DropIndex("dbo.Sales", new[] { "TruckId" });
            DropColumn("dbo.Sales", "TruckId");
            DropColumn("dbo.Sales", "GrossAmount");
            DropColumn("dbo.Sales", "PriceNet");
            DropColumn("dbo.Sales", "NumberOfLoads");
            DropColumn("dbo.Sales", "LoadVolume");
            DropColumn("dbo.Sales", "PriceOfWater");
            DropColumn("dbo.Payments", "SaleId");
            CreateIndex("dbo.Sales", "BillId");
            CreateIndex("dbo.Payments", "BillId");
            CreateIndex("dbo.Bills", "TruckId");
            AddForeignKey("dbo.GasReciepts", "TruckId", "dbo.WaterTrucks", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Sales", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GasReciepts", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Sales", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Payments", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Sales", "BillId", "dbo.Bills", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Bills", "TruckId", "dbo.WaterTrucks", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Payments", "BillId", "dbo.Bills", "Id", cascadeDelete: true);
        }
    }
}
