namespace CarRentalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class two : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rentals", "RentalCostCalculator", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rentals", "RentalCostCalculator");
        }
    }
}
