namespace CarRentalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class three : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Rentals", "RentalCostCalculator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rentals", "RentalCostCalculator", c => c.String());
        }
    }
}
