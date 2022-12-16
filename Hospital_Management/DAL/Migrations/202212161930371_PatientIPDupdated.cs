namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PatientIPDupdated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PatientIPDs", "Nid", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PatientIPDs", "Nid", c => c.String());
        }
    }
}
