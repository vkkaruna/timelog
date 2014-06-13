using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OrgBT.WebAPI.Models
{
    /// <summary>
    /// This model contains the properties of Projects
    /// </summary>
    public class ProjectViewModel
    {
        [Key]
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [ForeignKey("ProjectID")]
        public virtual ICollection<TaskViewModel> Tasks { get; set; }
    }

    /// <summary>
    /// This model contains the properties of Tasks of a project
    /// </summary>
    public class TaskViewModel
    {
        [Key]
        public int TaskID { get; set; }
        public int ProjectID { get; set; }
        public string TaskName { get; set; }
        public string TaskDesc { get; set; }
        public DateTime PlannedStartDate { get; set; }
        public DateTime PlannedEndDate { get; set; }
        public int EstimatedEffort { get; set; }

        [ForeignKey("TaskID")]
        public virtual ICollection<TimeSheetViewModel> TimeSheets { get; set; }

    }
}