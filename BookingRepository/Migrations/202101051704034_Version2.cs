namespace BookingRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Department", "DepartmentCode", c => c.String(nullable: false, maxLength: 8000, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Department", "DepartmentCode");
        }
    }
}
