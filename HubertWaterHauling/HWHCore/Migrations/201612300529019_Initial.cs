namespace HWHCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BillBases", newName: "GasReciepts");
            DropForeignKey("dbo.GasReciepts", "Sale_Id", "dbo.Sales");
            DropForeignKey("dbo.Payments", "CustomerId", "dbo.Customers");
            DropIndex("dbo.GasReciepts", new[] { "DriverEmployee_Id" });
            DropIndex("dbo.GasReciepts", new[] { "WaterTruck_Id" });
            DropIndex("dbo.GasReciepts", new[] { "Sale_Id" });
            DropIndex("dbo.Payments", new[] { "Sale_Id" });
            DropColumn("dbo.GasReciepts", "TruckId");
            RenameColumn(table: "dbo.GasReciepts", name: "DriverEmployee_Id", newName: "EmployeeId");
            RenameColumn(table: "dbo.GasReciepts", name: "WaterTruck_Id", newName: "TruckId");
            RenameColumn(table: "dbo.Payments", name: "Sale_Id", newName: "SaleId");
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PriceOfWater = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedDateTime = c.DateTime(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LoadOfWaters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoadVolume = c.Int(nullable: false),
                        BillId = c.Int(nullable: false),
                        TruckId = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bills", t => t.BillId)
                .ForeignKey("dbo.WaterTrucks", t => t.TruckId)
                .Index(t => t.BillId)
                .Index(t => t.TruckId);
            
            AddColumn("dbo.Addresses", "CustEmpDistinction", c => c.Int(nullable: false));
            AddColumn("dbo.Addresses", "ContactId", c => c.Int(nullable: false));
            AddColumn("dbo.Addresses", "CreatedDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Addresses", "ModifiedDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.ContactInfoes", "CustEmpDistinction", c => c.Int(nullable: false));
            AddColumn("dbo.ContactInfoes", "ContactId", c => c.Int(nullable: false));
            AddColumn("dbo.ContactInfoes", "CreatedDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.ContactInfoes", "ModifiedDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Customers", "Description", c => c.String());
            AddColumn("dbo.Customers", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "CreatedDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Customers", "ModifiedDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Employees", "HireDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Employees", "DateTerminated", c => c.DateTime());
            AddColumn("dbo.Employees", "Notes", c => c.String());
            AddColumn("dbo.Employees", "Title", c => c.String());
            AddColumn("dbo.Employees", "FirstName", c => c.String());
            AddColumn("dbo.Employees", "LastName", c => c.String());
            AddColumn("dbo.Employees", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Employees", "CreatedDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Employees", "ModifiedDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.GasReciepts", "RecieptTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.GasReciepts", "CreatedDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.GasReciepts", "ModifiedDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.WaterTrucks", "LoadVolume", c => c.Int(nullable: false));
            AddColumn("dbo.WaterTrucks", "CreatedDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.WaterTrucks", "ModifiedDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Payments", "CreatedDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Payments", "ModifiedDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Sales", "PaymentDueDate", c => c.DateTime());
            AddColumn("dbo.Sales", "DriverRetainagePercent", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Sales", "BillId", c => c.Int(nullable: false));
            AddColumn("dbo.Sales", "CustomerId", c => c.Int(nullable: false));
            AddColumn("dbo.Sales", "EmployeeId", c => c.Int(nullable: false));
            AddColumn("dbo.Sales", "CreatedDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Sales", "ModifiedDateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.GasReciepts", "TruckId", c => c.Int(nullable: false));
            AlterColumn("dbo.GasReciepts", "EmployeeId", c => c.Int(nullable: false));
            AlterColumn("dbo.GasReciepts", "TruckId", c => c.Int(nullable: false));
            AlterColumn("dbo.WaterTrucks", "PurchaseDate", c => c.DateTime());
            AlterColumn("dbo.Payments", "CheckNumber", c => c.Int());
            AlterColumn("dbo.Payments", "PaymentAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Payments", "SaleId", c => c.Int(nullable: false));
            CreateIndex("dbo.GasReciepts", "EmployeeId");
            CreateIndex("dbo.GasReciepts", "TruckId");
            CreateIndex("dbo.Sales", "BillId");
            CreateIndex("dbo.Sales", "CustomerId");
            CreateIndex("dbo.Sales", "EmployeeId");
            CreateIndex("dbo.Payments", "SaleId");
            AddForeignKey("dbo.Sales", "BillId", "dbo.Bills", "Id");
            AddForeignKey("dbo.Sales", "CustomerId", "dbo.Customers", "Id");
            AddForeignKey("dbo.Sales", "EmployeeId", "dbo.Employees", "Id");
            AddForeignKey("dbo.Payments", "CustomerId", "dbo.Customers", "Id");
            DropColumn("dbo.Customers", "Notes");
            DropColumn("dbo.Employees", "DriverFirstName");
            DropColumn("dbo.Employees", "DriverLastName");
            DropColumn("dbo.GasReciepts", "Amount");
            DropColumn("dbo.GasReciepts", "DriverId");
            DropColumn("dbo.GasReciepts", "Discriminator");
            DropColumn("dbo.GasReciepts", "Sale_Id");
            DropColumn("dbo.Sales", "AmountGross");
            DropColumn("dbo.Sales", "PriceOfWater");
            DropColumn("dbo.Sales", "NumberOfLoads");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sales", "NumberOfLoads", c => c.Int(nullable: false));
            AddColumn("dbo.Sales", "PriceOfWater", c => c.Single(nullable: false));
            AddColumn("dbo.Sales", "AmountGross", c => c.Single(nullable: false));
            AddColumn("dbo.GasReciepts", "Sale_Id", c => c.Int());
            AddColumn("dbo.GasReciepts", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.GasReciepts", "DriverId", c => c.Int());
            AddColumn("dbo.GasReciepts", "Amount", c => c.Single(nullable: false));
            AddColumn("dbo.Employees", "DriverLastName", c => c.String());
            AddColumn("dbo.Employees", "DriverFirstName", c => c.String());
            AddColumn("dbo.Customers", "Notes", c => c.String());
            DropForeignKey("dbo.Payments", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.LoadOfWaters", "TruckId", "dbo.WaterTrucks");
            DropForeignKey("dbo.Sales", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Sales", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Sales", "BillId", "dbo.Bills");
            DropForeignKey("dbo.LoadOfWaters", "BillId", "dbo.Bills");
            DropIndex("dbo.Payments", new[] { "SaleId" });
            DropIndex("dbo.Sales", new[] { "EmployeeId" });
            DropIndex("dbo.Sales", new[] { "CustomerId" });
            DropIndex("dbo.Sales", new[] { "BillId" });
            DropIndex("dbo.GasReciepts", new[] { "TruckId" });
            DropIndex("dbo.GasReciepts", new[] { "EmployeeId" });
            DropIndex("dbo.LoadOfWaters", new[] { "TruckId" });
            DropIndex("dbo.LoadOfWaters", new[] { "BillId" });
            AlterColumn("dbo.Payments", "SaleId", c => c.Int());
            AlterColumn("dbo.Payments", "PaymentAmount", c => c.Single(nullable: false));
            AlterColumn("dbo.Payments", "CheckNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.WaterTrucks", "PurchaseDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.GasReciepts", "TruckId", c => c.Int());
            AlterColumn("dbo.GasReciepts", "EmployeeId", c => c.Int());
            AlterColumn("dbo.GasReciepts", "TruckId", c => c.Int());
            DropColumn("dbo.Sales", "ModifiedDateTime");
            DropColumn("dbo.Sales", "CreatedDateTime");
            DropColumn("dbo.Sales", "EmployeeId");
            DropColumn("dbo.Sales", "CustomerId");
            DropColumn("dbo.Sales", "BillId");
            DropColumn("dbo.Sales", "DriverRetainagePercent");
            DropColumn("dbo.Sales", "PaymentDueDate");
            DropColumn("dbo.Payments", "ModifiedDateTime");
            DropColumn("dbo.Payments", "CreatedDateTime");
            DropColumn("dbo.WaterTrucks", "ModifiedDateTime");
            DropColumn("dbo.WaterTrucks", "CreatedDateTime");
            DropColumn("dbo.WaterTrucks", "LoadVolume");
            DropColumn("dbo.GasReciepts", "ModifiedDateTime");
            DropColumn("dbo.GasReciepts", "CreatedDateTime");
            DropColumn("dbo.GasReciepts", "RecieptTotal");
            DropColumn("dbo.Employees", "ModifiedDateTime");
            DropColumn("dbo.Employees", "CreatedDateTime");
            DropColumn("dbo.Employees", "IsActive");
            DropColumn("dbo.Employees", "LastName");
            DropColumn("dbo.Employees", "FirstName");
            DropColumn("dbo.Employees", "Title");
            DropColumn("dbo.Employees", "Notes");
            DropColumn("dbo.Employees", "DateTerminated");
            DropColumn("dbo.Employees", "HireDate");
            DropColumn("dbo.Customers", "ModifiedDateTime");
            DropColumn("dbo.Customers", "CreatedDateTime");
            DropColumn("dbo.Customers", "IsActive");
            DropColumn("dbo.Customers", "Description");
            DropColumn("dbo.ContactInfoes", "ModifiedDateTime");
            DropColumn("dbo.ContactInfoes", "CreatedDateTime");
            DropColumn("dbo.ContactInfoes", "ContactId");
            DropColumn("dbo.ContactInfoes", "CustEmpDistinction");
            DropColumn("dbo.Addresses", "ModifiedDateTime");
            DropColumn("dbo.Addresses", "CreatedDateTime");
            DropColumn("dbo.Addresses", "ContactId");
            DropColumn("dbo.Addresses", "CustEmpDistinction");
            DropTable("dbo.LoadOfWaters");
            DropTable("dbo.Bills");
            RenameColumn(table: "dbo.Payments", name: "SaleId", newName: "Sale_Id");
            RenameColumn(table: "dbo.GasReciepts", name: "TruckId", newName: "WaterTruck_Id");
            RenameColumn(table: "dbo.GasReciepts", name: "EmployeeId", newName: "DriverEmployee_Id");
            AddColumn("dbo.GasReciepts", "TruckId", c => c.Int());
            CreateIndex("dbo.Payments", "Sale_Id");
            CreateIndex("dbo.GasReciepts", "Sale_Id");
            CreateIndex("dbo.GasReciepts", "WaterTruck_Id");
            CreateIndex("dbo.GasReciepts", "DriverEmployee_Id");
            AddForeignKey("dbo.Payments", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GasReciepts", "Sale_Id", "dbo.Sales", "Id");
            RenameTable(name: "dbo.GasReciepts", newName: "BillBases");
        }
    }
}
