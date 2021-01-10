namespace BookingRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MeetingRoom",
                c => new
                    {
                        MeetingRoomId = c.Int(nullable: false, identity: true),
                        MeetingRoomName = c.String(nullable: false, maxLength: 8000, unicode: false),
                        RoomCapacity = c.Int(nullable: false),
                        Projector = c.Boolean(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MeetingRoomId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MeetingRoom");
        }
    }
}
