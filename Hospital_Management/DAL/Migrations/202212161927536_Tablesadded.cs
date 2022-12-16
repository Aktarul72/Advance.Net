namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tablesadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cabins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 50),
                        Status = c.String(nullable: false, maxLength: 30),
                        Rent = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerOPDs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Address = c.String(nullable: false, maxLength: 250),
                        Age = c.Int(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        Gender = c.String(nullable: false, maxLength: 20),
                        MaritalStatus = c.String(nullable: false),
                        BloodGroup = c.String(),
                        Phone = c.String(nullable: false, maxLength: 15),
                        RefdBy = c.String(nullable: false, maxLength: 180),
                        Remark = c.String(maxLength: 180),
                        DeliveryDate = c.DateTime(nullable: false),
                        DeliveryStatus = c.String(maxLength: 40),
                        DoctorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Address = c.String(nullable: false, maxLength: 250),
                        Gender = c.String(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 15),
                        Qualification = c.String(nullable: false, maxLength: 300),
                        Specialization = c.String(nullable: false, maxLength: 300),
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
                        SupplierId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OPDBillings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemTotal = c.Double(nullable: false),
                        TotalVat = c.Double(nullable: false),
                        Discount = c.Double(nullable: false),
                        TotalBill = c.Double(nullable: false),
                        PaidAmount = c.Double(nullable: false),
                        DueAmount = c.Double(nullable: false),
                        PaymentStatus = c.String(nullable: false, maxLength: 10),
                        CustomerOPDId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerOPDs", t => t.CustomerOPDId, cascadeDelete: true)
                .Index(t => t.CustomerOPDId);
            
            CreateTable(
                "dbo.OPDOrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OPDBillingId = c.Int(nullable: false),
                        ItemExamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ItemExams", t => t.ItemExamId, cascadeDelete: true)
                .ForeignKey("dbo.OPDBillings", t => t.OPDBillingId, cascadeDelete: true)
                .Index(t => t.OPDBillingId)
                .Index(t => t.ItemExamId);
            
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
                        RefdBy = c.String(nullable: false, maxLength: 180),
                        DutyDoctor = c.String(maxLength: 180),
                        DoctorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.PatientIPDs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        FatherName = c.String(nullable: false, maxLength: 200),
                        MotherName = c.String(nullable: false, maxLength: 200),
                        Address = c.String(nullable: false, maxLength: 250),
                        Gender = c.String(nullable: false, maxLength: 20),
                        Age = c.Int(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 15),
                        Occupation = c.String(maxLength: 80),
                        Nid = c.String(),
                        AdmissionDate = c.DateTime(nullable: false),
                        RefdBy = c.String(nullable: false, maxLength: 180),
                        DutyDoctor = c.String(maxLength: 180),
                        PaidAmount = c.Double(nullable: false),
                        PaymentStatus = c.String(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        CabinId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cabins", t => t.CabinId, cascadeDelete: true)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .Index(t => t.DoctorId)
                .Index(t => t.CabinId);
            
            CreateTable(
                "dbo.PharmacyBillings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemTotal = c.Double(nullable: false),
                        TotalVat = c.Double(nullable: false),
                        Discount = c.Double(nullable: false),
                        TotalBill = c.Double(nullable: false),
                        PaidAmount = c.Double(nullable: false),
                        DueAmount = c.Double(nullable: false),
                        PaymentStatus = c.String(nullable: false, maxLength: 10),
                        CustomerPharmacyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerPharmacies", t => t.CustomerPharmacyId, cascadeDelete: true)
                .Index(t => t.CustomerPharmacyId);
            
            CreateTable(
                "dbo.PharmacyOrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PharmacyBillingId = c.Int(nullable: false),
                        MedicineId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Medicines", t => t.MedicineId, cascadeDelete: true)
                .ForeignKey("dbo.PharmacyBillings", t => t.PharmacyBillingId, cascadeDelete: true)
                .Index(t => t.PharmacyBillingId)
                .Index(t => t.MedicineId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PharmacyOrderDetails", "PharmacyBillingId", "dbo.PharmacyBillings");
            DropForeignKey("dbo.PharmacyOrderDetails", "MedicineId", "dbo.Medicines");
            DropForeignKey("dbo.PharmacyBillings", "CustomerPharmacyId", "dbo.CustomerPharmacies");
            DropForeignKey("dbo.PatientIPDs", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.PatientIPDs", "CabinId", "dbo.Cabins");
            DropForeignKey("dbo.OTDetails", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.OPDOrderDetails", "OPDBillingId", "dbo.OPDBillings");
            DropForeignKey("dbo.OPDOrderDetails", "ItemExamId", "dbo.ItemExams");
            DropForeignKey("dbo.OPDBillings", "CustomerOPDId", "dbo.CustomerOPDs");
            DropForeignKey("dbo.Medicines", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.CustomerOPDs", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.PharmacyOrderDetails", new[] { "MedicineId" });
            DropIndex("dbo.PharmacyOrderDetails", new[] { "PharmacyBillingId" });
            DropIndex("dbo.PharmacyBillings", new[] { "CustomerPharmacyId" });
            DropIndex("dbo.PatientIPDs", new[] { "CabinId" });
            DropIndex("dbo.PatientIPDs", new[] { "DoctorId" });
            DropIndex("dbo.OTDetails", new[] { "DoctorId" });
            DropIndex("dbo.OPDOrderDetails", new[] { "ItemExamId" });
            DropIndex("dbo.OPDOrderDetails", new[] { "OPDBillingId" });
            DropIndex("dbo.OPDBillings", new[] { "CustomerOPDId" });
            DropIndex("dbo.Medicines", new[] { "SupplierId" });
            DropIndex("dbo.CustomerOPDs", new[] { "DoctorId" });
            DropTable("dbo.PharmacyOrderDetails");
            DropTable("dbo.PharmacyBillings");
            DropTable("dbo.PatientIPDs");
            DropTable("dbo.OTDetails");
            DropTable("dbo.OPDOrderDetails");
            DropTable("dbo.OPDBillings");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Medicines");
            DropTable("dbo.Materials");
            DropTable("dbo.ItemExams");
            DropTable("dbo.Employees");
            DropTable("dbo.CustomerPharmacies");
            DropTable("dbo.Doctors");
            DropTable("dbo.CustomerOPDs");
            DropTable("dbo.Cabins");
        }
    }
}
