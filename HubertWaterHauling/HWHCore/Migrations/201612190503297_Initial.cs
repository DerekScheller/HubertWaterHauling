namespace HWHCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
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
                        Customer_Id = c.Int(),
                        Employee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.Employee_Id);
            
            CreateTable(
                "dbo.ContactInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactInfoType = c.Int(nullable: false),
                        AssociationType = c.Int(nullable: false),
                        Notes = c.String(),
                        ContactDetail = c.String(),
                        Customer_Id = c.Int(),
                        Employee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.Employee_Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MiddleInitial = c.String(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DriverFirstName = c.String(),
                        DriverLastName = c.String(),
                        MiddleInitial = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BillBases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Single(nullable: false),
                        DriverId = c.Int(),
                        TruckId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        DriverEmployee_Id = c.Int(),
                        WaterTruck_Id = c.Int(),
                        Sale_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.DriverEmployee_Id)
                .ForeignKey("dbo.WaterTrucks", t => t.WaterTruck_Id)
                .ForeignKey("dbo.Sales", t => t.Sale_Id)
                .Index(t => t.DriverEmployee_Id)
                .Index(t => t.WaterTruck_Id)
                .Index(t => t.Sale_Id);
            
            CreateTable(
                "dbo.WaterTrucks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ManufactureYear = c.DateTime(nullable: false),
                        PurchaseDate = c.DateTime(nullable: false),
                        Model = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaymentType = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        CheckNumber = c.Int(nullable: false),
                        PaymentAmount = c.Single(nullable: false),
                        Sale_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Sales", t => t.Sale_Id)
                .Index(t => t.CustomerId)
                .Index(t => t.Sale_Id);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SaleType = c.Int(nullable: false),
                        AmountGross = c.Single(nullable: false),
                        DateOfSale = c.DateTime(nullable: false),
                        FullPaymentRecieved = c.Boolean(nullable: false),
                        PriceOfWater = c.Single(nullable: false),
                        NumberOfLoads = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "Sale_Id", "dbo.Sales");
            DropForeignKey("dbo.BillBases", "Sale_Id", "dbo.Sales");
            DropForeignKey("dbo.Payments", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.BillBases", "WaterTruck_Id", "dbo.WaterTrucks");
            DropForeignKey("dbo.BillBases", "DriverEmployee_Id", "dbo.Employees");
            DropForeignKey("dbo.ContactInfoes", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.Addresses", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.ContactInfoes", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Addresses", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Payments", new[] { "Sale_Id" });
            DropIndex("dbo.Payments", new[] { "CustomerId" });
            DropIndex("dbo.BillBases", new[] { "Sale_Id" });
            DropIndex("dbo.BillBases", new[] { "WaterTruck_Id" });
            DropIndex("dbo.BillBases", new[] { "DriverEmployee_Id" });
            DropIndex("dbo.ContactInfoes", new[] { "Employee_Id" });
            DropIndex("dbo.ContactInfoes", new[] { "Customer_Id" });
            DropIndex("dbo.Addresses", new[] { "Employee_Id" });
            DropIndex("dbo.Addresses", new[] { "Customer_Id" });
            DropTable("dbo.Sales");
            DropTable("dbo.Payments");
            DropTable("dbo.WaterTrucks");
            DropTable("dbo.BillBases");
            DropTable("dbo.Employees");
            DropTable("dbo.Customers");
            DropTable("dbo.ContactInfoes");
            DropTable("dbo.Addresses");
        }
    }
}
