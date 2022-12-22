namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pharmacybilltableupdate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PharmacyOrderDetails", "MedicineName", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PharmacyOrderDetails", "MedicineName", c => c.Int(nullable: false));
        }
    }
}
