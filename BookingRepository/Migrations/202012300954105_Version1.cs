namespace BookingRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Staff",
                c => new
                    {
                        StaffId = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 8000, unicode: false),
                        FullName = c.String(maxLength: 8000, unicode: false),
                        Password = c.String(maxLength: 8000, unicode: false),
                        UserRole = c.String(maxLength: 8000, unicode: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StaffId)
                .ForeignKey("dbo.Department", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Staff", "DepartmentId", "dbo.Department");
            DropIndex("dbo.Staff", new[] { "DepartmentId" });
            DropTable("dbo.Staff");
            DropTable("dbo.Department");
        }
    }
}
