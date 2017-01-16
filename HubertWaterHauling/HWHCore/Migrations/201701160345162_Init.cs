namespace HWHCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddressStreet1 = c.String(),
                        AddressStreet2 = c.String(),
                        AddressStreet3 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        Country = c.String(),
                        AddressType = c.Int(nullable: false),
                        CustomerId = c.Int(),
                        EmployeeId = c.Int(),
                        CreatedDateTime = c.DateTime(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.CustomerId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MiddleInitial = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContactInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactInfoType = c.Int(nullable: false),
                        AssociationType = c.Int(nullable: false),
                        Notes = c.String(),
                        ContactDetail = c.String(),
                        EmployeeId = c.Int(),
                        CustomerId = c.Int(),
                        CreatedDateTime = c.DateTime(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.EmployeeId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HireDate = c.DateTime(nullable: false),
                        DateTerminated = c.DateTime(),
                        Notes = c.String(),
                        Title = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MiddleInitial = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GasReciepts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        TruckId = c.Int(nullable: false),
                        RecieptTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Notes = c.String(),
                        CreatedDateTime = c.DateTime(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.WaterTrucks", t => t.TruckId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.TruckId);
            
            CreateTable(
                "dbo.WaterTrucks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ManufactureYear = c.DateTime(nullable: false),
                        PurchaseDate = c.DateTime(),
                        Model = c.String(),
                        Make = c.String(),
                        LoadVolume = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WaterTrucks", t => t.TruckId, cascadeDelete: true)
                .Index(t => t.TruckId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaymentType = c.Int(nullable: false),
                        CheckNumber = c.Int(),
                        PaymentAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CustomerId = c.Int(nullable: false),
                        BillId = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bills", t => t.BillId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.BillId);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SaleType = c.Int(nullable: false),
                        DateOfSale = c.DateTime(nullable: false),
                        PaymentDueDate = c.DateTime(),
                        FullPaymentRecieved = c.Boolean(nullable: false),
                        DriverRetainagePercent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BillId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bills", t => t.BillId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.BillId)
                .Index(t => t.CustomerId)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sales", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Sales", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Sales", "BillId", "dbo.Bills");
            DropForeignKey("dbo.GasReciepts", "TruckId", "dbo.WaterTrucks");
            DropForeignKey("dbo.Bills", "TruckId", "dbo.WaterTrucks");
            DropForeignKey("dbo.Payments", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Payments", "BillId", "dbo.Bills");
            DropForeignKey("dbo.GasReciepts", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.ContactInfoes", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Addresses", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.ContactInfoes", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Addresses", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Sales", new[] { "EmployeeId" });
            DropIndex("dbo.Sales", new[] { "CustomerId" });
            DropIndex("dbo.Sales", new[] { "BillId" });
            DropIndex("dbo.Payments", new[] { "BillId" });
            DropIndex("dbo.Payments", new[] { "CustomerId" });
            DropIndex("dbo.Bills", new[] { "TruckId" });
            DropIndex("dbo.GasReciepts", new[] { "TruckId" });
            DropIndex("dbo.GasReciepts", new[] { "EmployeeId" });
            DropIndex("dbo.ContactInfoes", new[] { "CustomerId" });
            DropIndex("dbo.ContactInfoes", new[] { "EmployeeId" });
            DropIndex("dbo.Addresses", new[] { "EmployeeId" });
            DropIndex("dbo.Addresses", new[] { "CustomerId" });
            DropTable("dbo.Sales");
            DropTable("dbo.Payments");
            DropTable("dbo.Bills");
            DropTable("dbo.WaterTrucks");
            DropTable("dbo.GasReciepts");
            DropTable("dbo.Employees");
            DropTable("dbo.ContactInfoes");
            DropTable("dbo.Customers");
            DropTable("dbo.Addresses");
        }
    }
}
