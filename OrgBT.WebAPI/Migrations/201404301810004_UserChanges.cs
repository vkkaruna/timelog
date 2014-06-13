namespace OrgBT.WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserChanges : DbMigration
    {
        public override void Up()
        {
            // Making this change to avoid reading the username from account system
            // assuming this is not scope of this task
            AddColumn("dbo.TimeSheetViewModels", "UserName", c => c.String());
            DropColumn("dbo.TimeSheetViewModels", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TimeSheetViewModels", "UserID", c => c.Guid(nullable: false));
            DropColumn("dbo.TimeSheetViewModels", "UserName");
        }
    }
}
