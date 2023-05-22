namespace CarRentalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class five : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rentals", "CarRentalCostPerHour", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rentals", "CarRentalCostPerHour");
        }
    }
}
