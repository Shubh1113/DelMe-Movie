namespace DelMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedPhoneNoToApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "PhoneNo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "PhoneNo");
        }
    }
}
