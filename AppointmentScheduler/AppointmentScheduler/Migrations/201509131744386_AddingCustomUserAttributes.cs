namespace AppointmentScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingCustomUserAttributes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "FirstName", c => c.String());
            AddColumn("dbo.User", "LastName", c => c.String());
            AddColumn("dbo.User", "MobileNumber", c => c.String());
            AddColumn("dbo.User", "Address", c => c.String());
            AddColumn("dbo.User", "City", c => c.String());
            AddColumn("dbo.User", "State", c => c.String());
            AddColumn("dbo.User", "ZipCode", c => c.String());
            AddColumn("dbo.User", "Notes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "Notes");
            DropColumn("dbo.User", "ZipCode");
            DropColumn("dbo.User", "State");
            DropColumn("dbo.User", "City");
            DropColumn("dbo.User", "Address");
            DropColumn("dbo.User", "MobileNumber");
            DropColumn("dbo.User", "LastName");
            DropColumn("dbo.User", "FirstName");
        }
    }
}
