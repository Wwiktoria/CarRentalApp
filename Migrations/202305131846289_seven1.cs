namespace CarRentalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seven1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Rentals", "CarRentalCost");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rentals", "CarRentalCost", c => c.String());
        }
    }
}
