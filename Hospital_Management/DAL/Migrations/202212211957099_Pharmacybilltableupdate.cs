namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pharmacybilltableupdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OPDBillings", "Discount", c => c.Double());
            AlterColumn("dbo.PharmacyBillings", "Discount", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PharmacyBillings", "Discount", c => c.Double(nullable: false));
            AlterColumn("dbo.OPDBillings", "Discount", c => c.Double(nullable: false));
        }
    }
}
