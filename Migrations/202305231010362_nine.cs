namespace CarRentalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nine : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rentals", "Rental_RentalId", c => c.Int());
            CreateIndex("dbo.Rentals", "Rental_RentalId");
            AddForeignKey("dbo.Rentals", "Rental_RentalId", "dbo.Rentals", "RentalId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "Rental_RentalId", "dbo.Rentals");
            DropIndex("dbo.Rentals", new[] { "Rental_RentalId" });
            DropColumn("dbo.Rentals", "Rental_RentalId");
        }
    }
}
