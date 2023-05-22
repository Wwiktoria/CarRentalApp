namespace CarRentalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class six : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Rentals", "CarRentalCostPerHour");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rentals", "CarRentalCostPerHour", c => c.String());
        }
    }
}
