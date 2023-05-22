namespace CarRentalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eight : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rentals", "ShowNotification", c => c.Boolean(nullable: false));
            AddColumn("dbo.Rentals", "NotificationMessage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rentals", "NotificationMessage");
            DropColumn("dbo.Rentals", "ShowNotification");
        }
    }
}
