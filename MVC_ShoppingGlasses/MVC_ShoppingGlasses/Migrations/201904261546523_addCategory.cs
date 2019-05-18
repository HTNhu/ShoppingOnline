namespace MVC_ShoppingGlasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        AccID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AccID);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerID = c.Int(nullable: false),
                        Name = c.String(maxLength: 30, fixedLength: true),
                        Gender = c.String(maxLength: 10, fixedLength: true),
                        Address = c.String(maxLength: 50, fixedLength: true),
                        PhoneNumber = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.CustomerID)
                .ForeignKey("dbo.Account", t => t.CustomerID)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        State = c.String(nullable: false, maxLength: 40),
                        PhoneNumber = c.String(nullable: false, maxLength: 40),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Customers_CustomerID = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Customer", t => t.Customers_CustomerID)
                .Index(t => t.Customers_CustomerID);
            
            CreateTable(
                "dbo.OrderDatail",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Product_ProductID = c.Int(),
                    })
                .PrimaryKey(t => t.OrderDetailId)
                .ForeignKey("dbo.Product", t => t.Product_ProductID)
                .ForeignKey("dbo.Order", t => t.OrderId)
                .Index(t => t.OrderId)
                .Index(t => t.Product_ProductID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ImgURL = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        Unitinstock = c.Int(nullable: false),
                        Original = c.String(nullable: false),
                        State = c.String(),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Category", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 20, fixedLength: true),
                        Gender = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        Address = c.String(nullable: false, maxLength: 50, fixedLength: true),
                        PhoneNumber = c.String(nullable: false, maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Account", t => t.EmployeeID)
                .Index(t => t.EmployeeID);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "EmployeeID", "dbo.Account");
            DropForeignKey("dbo.Customer", "CustomerID", "dbo.Account");
            DropForeignKey("dbo.Order", "Customers_CustomerID", "dbo.Customer");
            DropForeignKey("dbo.OrderDatail", "OrderId", "dbo.Order");
            DropForeignKey("dbo.OrderDatail", "Product_ProductID", "dbo.Product");
            DropForeignKey("dbo.Product", "CategoryID", "dbo.Category");
            DropIndex("dbo.Employee", new[] { "EmployeeID" });
            DropIndex("dbo.Product", new[] { "CategoryID" });
            DropIndex("dbo.OrderDatail", new[] { "Product_ProductID" });
            DropIndex("dbo.OrderDatail", new[] { "OrderId" });
            DropIndex("dbo.Order", new[] { "Customers_CustomerID" });
            DropIndex("dbo.Customer", new[] { "CustomerID" });
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.Employee");
            DropTable("dbo.Category");
            DropTable("dbo.Product");
            DropTable("dbo.OrderDatail");
            DropTable("dbo.Order");
            DropTable("dbo.Customer");
            DropTable("dbo.Account");
        }
    }
}
