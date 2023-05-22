namespace CarRentalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seven : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rentals", "CarRentalCost", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rentals", "CarRentalCost");
        }
    }
}
