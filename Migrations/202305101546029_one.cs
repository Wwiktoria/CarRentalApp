namespace CarRentalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class one : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        BookingDate = c.DateTime(nullable: false),
                        BookingStartDate = c.DateTime(nullable: false),
                        BookingEndDate = c.DateTime(nullable: false),
                        BookingCost = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        CarRegistrationNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookingId)
                .ForeignKey("dbo.Cars", t => t.CarRegistrationNumber, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.CarRegistrationNumber);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        CarRegistrationNumber = c.Int(nullable: false, identity: true),
                        CarRegistrationNumberNotKey = c.String(nullable: false),
                        CarYearOfProduction = c.String(nullable: false),
                        CarMileage = c.String(nullable: false),
                        CarIsRented = c.Boolean(nullable: false),
                        CarModelId = c.Int(nullable: false),
                        CarRentalCost = c.String(nullable: false),
                        CarPower = c.String(nullable: false),
                        CarColor = c.String(nullable: false),
                        CarNumberOfSeats = c.String(nullable: false),
                        CarBodyType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CarRegistrationNumber)
                .ForeignKey("dbo.CarModels", t => t.CarModelId, cascadeDelete: true)
                .Index(t => t.CarModelId);
            
            CreateTable(
                "dbo.CarModels",
                c => new
                    {
                        CarModelId = c.Int(nullable: false, identity: true),
                        CarBrandName = c.String(nullable: false),
                        CarModelName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CarModelId);
            
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        RentalId = c.Int(nullable: false, identity: true),
                        RentalCost = c.Int(nullable: false),
                        RentalStartDate = c.DateTime(nullable: false),
                        RentalEndDate = c.DateTime(nullable: false),
                        ClientId = c.Int(nullable: false),
                        WorkerId = c.Int(nullable: false),
                        CarRegistrationNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RentalId)
                .ForeignKey("dbo.Cars", t => t.CarRegistrationNumber, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Workers", t => t.WorkerId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.WorkerId)
                .Index(t => t.CarRegistrationNumber);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        ClientName = c.String(nullable: false),
                        ClientSurname = c.String(nullable: false),
                        ClientDocumentId = c.String(nullable: false),
                        ClientDocumentName = c.Int(nullable: false),
                        ClientTelephone = c.String(nullable: false),
                        ClientEmail = c.String(nullable: false),
                        ClientStreet = c.String(nullable: false),
                        ClientBuildingNumber = c.String(nullable: false),
                        ClientFlatNumber = c.String(nullable: false),
                        ClientCity = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "dbo.Workers",
                c => new
                    {
                        WorkerId = c.Int(nullable: false, identity: true),
                        WorkerName = c.String(nullable: false),
                        WorkerSurname = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.WorkerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "WorkerId", "dbo.Workers");
            DropForeignKey("dbo.Rentals", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Bookings", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Rentals", "CarRegistrationNumber", "dbo.Cars");
            DropForeignKey("dbo.Cars", "CarModelId", "dbo.CarModels");
            DropForeignKey("dbo.Bookings", "CarRegistrationNumber", "dbo.Cars");
            DropIndex("dbo.Rentals", new[] { "CarRegistrationNumber" });
            DropIndex("dbo.Rentals", new[] { "WorkerId" });
            DropIndex("dbo.Rentals", new[] { "ClientId" });
            DropIndex("dbo.Cars", new[] { "CarModelId" });
            DropIndex("dbo.Bookings", new[] { "CarRegistrationNumber" });
            DropIndex("dbo.Bookings", new[] { "ClientId" });
            DropTable("dbo.Workers");
            DropTable("dbo.Clients");
            DropTable("dbo.Rentals");
            DropTable("dbo.CarModels");
            DropTable("dbo.Cars");
            DropTable("dbo.Bookings");
        }
    }
}
