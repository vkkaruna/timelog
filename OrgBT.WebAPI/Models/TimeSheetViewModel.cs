using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrgBT.WebAPI.Models
{
    /// <summary>
    /// This model contains properties to hold timesheet data entered by a developer
    /// </summary>
    public class TimeSheetViewModel
    {
        [Key]
        public int TimeSheetID { get; set; }
        public int TaskID { get; set; }
        public int ProjectID { get; set; }

        // User Name from Account System
        public string UserName { get; set; }
        public DateTime ActualStartDate { get; set; }
        public DateTime ActualEndDate { get; set; }
        public int ActualEffort { get; set; }
        public TaskStatus Status { get; set; }
    }

    /// <summary>
    /// Enum describes different status of a task
    /// </summary>
    public enum TaskStatus
    {
        Submitted,
        Approved,
        Rejected
    }

    /// <summary>
    /// This class exposes a model that can be bound to developer time log
    /// </summary>
    public class TimeLogBindingModel
    {
        [Required]
        public int ProjectID { get; set; }

        [Required]
        [Key]
        public int TaskID { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ActualStartDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ActualEndDate { get; set; }

        [Required]
        public int ActualEffort { get; set; }
    }
}