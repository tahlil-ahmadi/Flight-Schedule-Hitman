namespace FlightSchedule.Persistence.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialStep : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Origin = c.String(nullable: false),
                        Destination = c.String(nullable: false),
                        DepartDate = c.DateTime(nullable: false),
                        ArriveDate = c.DateTime(nullable: false),
                        FlightNumber = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Flights");
        }
    }
}
