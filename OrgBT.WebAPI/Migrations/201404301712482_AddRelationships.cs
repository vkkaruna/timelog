namespace OrgBT.WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationships : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.TimeSheetViewModels", "TaskID");
            CreateIndex("dbo.TaskViewModels", "ProjectID");
            AddForeignKey("dbo.TimeSheetViewModels", "TaskID", "dbo.TaskViewModels", "TaskID", cascadeDelete: true);
            AddForeignKey("dbo.TaskViewModels", "ProjectID", "dbo.ProjectViewModels", "ProjectID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaskViewModels", "ProjectID", "dbo.ProjectViewModels");
            DropForeignKey("dbo.TimeSheetViewModels", "TaskID", "dbo.TaskViewModels");
            DropIndex("dbo.TaskViewModels", new[] { "ProjectID" });
            DropIndex("dbo.TimeSheetViewModels", new[] { "TaskID" });
        }
    }
}
