using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using OrgBT.WebAPI.Models;

namespace OrgBT.WebAPI.Controllers
{
    [Authorize] 
    [RoutePrefix("api/TimeSheet")]
    public class TimeSheetController : ApiController
    {
        private TimeContext db = new TimeContext();

        // GET api/TimeSheets/Project?projectID=1
        [Route("Project")]
        [Authorize(Roles = "Client")]
        public IHttpActionResult GetTimeSheets(int projectID)
        {
            var timesheets = (from ts in db.TimeSheets
                              join timeTask in db.Tasks on ts.TaskID equals timeTask.TaskID
                              where ts.ProjectID == projectID
                              select new
                              {
                                  TimeSheetID = ts.TimeSheetID,
                                  TaskName = timeTask.TaskName,
                                  TaskDesc = timeTask.TaskDesc,
                                  EstimatedEffort = timeTask.EstimatedEffort,
                                  UserName = ts.UserName,
                                  ActualEffort = ts.ActualEffort,
                                  ActualStartDate = ts.ActualStartDate,
                                  ActualEndDate = ts.ActualEndDate,
                                  Status = ts.Status
                              }).Take(1000);
            if (timesheets == null)
            {
                return NotFound();
            }

            return Ok(timesheets);
        }

        // GET api/TimeSheets/5
        [Authorize(Roles = "Client")]
        [ResponseType(typeof(TimeSheetViewModel))]
        public IHttpActionResult GetTimeSheet(int id)
        {
            TimeSheetViewModel timesheet = db.TimeSheets.Find(id);
            if (timesheet == null)
            {
                return NotFound();
            }

            return Ok(timesheet);
        }

        // PUT api/TimeSheets/5
        public IHttpActionResult PutTimeSheet(int id, TimeSheetViewModel timesheet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != timesheet.TimeSheetID)
            {
                return BadRequest();
            }

            db.Entry(timesheet).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimeSheetExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/TimeSheets
        [ResponseType(typeof(TimeSheetViewModel))]
        public IHttpActionResult PostTimeSheet(TimeLogBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Build timesheet entity with the binding model
            var timeSheet = new TimeSheetViewModel()
            {
                ProjectID = model.ProjectID,
                TaskID = model.TaskID,
                UserName = User.Identity.Name,
                ActualEffort = model.ActualEffort,
                ActualStartDate = model.ActualStartDate,
                ActualEndDate = model.ActualEndDate
            };

            db.TimeSheets.Add(timeSheet);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = timeSheet.TimeSheetID }, timeSheet);
        }

        // DELETE api/TimeSheets/5
        [Authorize(Roles = "Client")]
        [ResponseType(typeof(TimeSheetViewModel))]
        public IHttpActionResult DeleteTimeSheet(int id)
        {
            TimeSheetViewModel timesheet = db.TimeSheets.Find(id);
            if (timesheet == null)
            {
                return NotFound();
            }

            db.TimeSheets.Remove(timesheet);
            db.SaveChanges();

            return Ok(timesheet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TimeSheetExists(int id)
        {
            return db.TimeSheets.Count(e => e.TimeSheetID == id) > 0;
        }
    }
}