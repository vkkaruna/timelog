using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace OrgBT.WebAPI.Models
{
    /// <summary>
    /// This DB context instance represent a bouded context of logging
    /// time by a developer and monitered by a client
    /// </summary>
    public class TimeContext : DbContext
    {
        public DbSet<ProjectViewModel> Projects { get; set; }
        public DbSet<TaskViewModel> Tasks { get; set; }
        public DbSet<TimeSheetViewModel> TimeSheets { get; set; }
    }
}