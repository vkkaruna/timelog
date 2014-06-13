namespace OrgBT.WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectViewModels",
                c => new
                    {
                        ProjectID = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectID);
            
            CreateTable(
                "dbo.TaskViewModels",
                c => new
                    {
                        TaskID = c.Int(nullable: false, identity: true),
                        ProjectID = c.Int(nullable: false),
                        TaskName = c.String(),
                        TaskDesc = c.String(),
                        PlannedStartDate = c.DateTime(nullable: false),
                        PlannedEndDate = c.DateTime(nullable: false),
                        EstimatedEffort = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TaskID);
            
            CreateTable(
                "dbo.TimeSheetViewModels",
                c => new
                    {
                        TimeSheetID = c.Int(nullable: false, identity: true),
                        TaskID = c.Int(nullable: false),
                        ProjectID = c.Int(nullable: false),
                        UserID = c.Guid(nullable: false),
                        ActualStartDate = c.DateTime(nullable: false),
                        ActualEndDate = c.DateTime(nullable: false),
                        ActualEffort = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TimeSheetID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TimeSheetViewModels");
            DropTable("dbo.TaskViewModels");
            DropTable("dbo.ProjectViewModels");
        }
    }
}
