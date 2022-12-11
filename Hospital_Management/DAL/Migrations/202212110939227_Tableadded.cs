namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tableadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cabins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 50),
                        Rent = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerOPDs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        FatherName = c.String(maxLength: 200),
                        MotherName = c.String(maxLength: 200),
                        Address = c.String(nullable: false, maxLength: 250),
                        Age = c.Int(nullable: false),
                        DOB = c.String(),
                        Gender = c.String(nullable: false, maxLength: 20),
                        Phone = c.String(nullable: false, maxLength: 15),
                        Occupation = c.String(maxLength: 80),
                        DoctorId = c.Int(nullable: false),
                        PaymentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.PaymentInfoes", t => t.PaymentId, cascadeDelete: true)
                .Index(t => t.DoctorId)
                .Index(t => t.PaymentId);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Address = c.String(nullable: false, maxLength: 250),
                        Gender = c.String(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 15),
                        Designation = c.String(nullable: false, maxLength: 300),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PaymentInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaymentType = c.String(nullable: false, maxLength: 20),
                        Amount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerPharmacies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Address = c.String(nullable: false, maxLength: 250),
                        Gender = c.String(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Address = c.String(nullable: false, maxLength: 250),
                        Gender = c.String(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 15),
                        Role = c.String(nullable: false, maxLength: 50),
                        Username = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 8),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ItemExams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Rate = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Details = c.String(nullable: false, maxLength: 200),
                        Quantity = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Medicines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Rate = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OTDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        FatherName = c.String(nullable: false, maxLength: 200),
                        MotherName = c.String(nullable: false, maxLength: 200),
                        Address = c.String(nullable: false, maxLength: 250),
                        Age = c.Int(nullable: false),
                        Gender = c.String(nullable: false, maxLength: 20),
                        Phone = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PatientIPDs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        FatherName = c.String(nullable: false, maxLength: 200),
                        MotherName = c.String(nullable: false, maxLength: 200),
                        Address = c.String(nullable: false, maxLength: 250),
                        Age = c.Int(nullable: false),
                        DOB = c.String(),
                        Gender = c.String(nullable: false, maxLength: 20),
                        Phone = c.String(nullable: false, maxLength: 15),
                        Occupation = c.String(maxLength: 80),
                        DoctorId = c.Int(nullable: false),
                        CabinId = c.Int(nullable: false),
                        PaymentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cabins", t => t.CabinId, cascadeDelete: true)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.PaymentInfoes", t => t.PaymentId, cascadeDelete: true)
                .Index(t => t.DoctorId)
                .Index(t => t.CabinId)
                .Index(t => t.PaymentId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PatientIPDs", "PaymentId", "dbo.PaymentInfoes");
            DropForeignKey("dbo.PatientIPDs", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.PatientIPDs", "CabinId", "dbo.Cabins");
            DropForeignKey("dbo.CustomerOPDs", "PaymentId", "dbo.PaymentInfoes");
            DropForeignKey("dbo.CustomerOPDs", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.PatientIPDs", new[] { "PaymentId" });
            DropIndex("dbo.PatientIPDs", new[] { "CabinId" });
            DropIndex("dbo.PatientIPDs", new[] { "DoctorId" });
            DropIndex("dbo.CustomerOPDs", new[] { "PaymentId" });
            DropIndex("dbo.CustomerOPDs", new[] { "DoctorId" });
            DropTable("dbo.Suppliers");
            DropTable("dbo.PatientIPDs");
            DropTable("dbo.OTDetails");
            DropTable("dbo.Medicines");
            DropTable("dbo.Materials");
            DropTable("dbo.ItemExams");
            DropTable("dbo.Employees");
            DropTable("dbo.CustomerPharmacies");
            DropTable("dbo.PaymentInfoes");
            DropTable("dbo.Doctors");
            DropTable("dbo.CustomerOPDs");
            DropTable("dbo.Cabins");
        }
    }
}
