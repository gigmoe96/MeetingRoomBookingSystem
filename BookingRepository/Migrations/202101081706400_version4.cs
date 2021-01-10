namespace BookingRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Booking", "BookingDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Booking", "StartTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Booking", "EndTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Booking", "ExtendedTime", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Booking", "ExtendedTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Booking", "EndTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Booking", "StartTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Booking", "BookingDate", c => c.DateTime(nullable: false));
        }
    }
}
