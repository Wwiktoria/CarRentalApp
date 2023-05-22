namespace CarRentalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class six3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rentals", "RentalCost", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rentals", "RentalCost");
        }
    }
}
