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
    public class TaskController : ApiController
    {
        private TimeContext db = new TimeContext();

        // GET api/Task
        public IQueryable<TaskViewModel> GetTasks()
        {
            return db.Tasks;
        }

        // GET api/Task/5
        [ResponseType(typeof(TaskViewModel))]
        [Authorize]
        public IHttpActionResult GetTasksByProjectID(int id)
        {
            TaskViewModel taskviewmodel = db.Tasks.Find(id);
            if (taskviewmodel == null)
            {
                return NotFound();
            }

            return Ok(taskviewmodel);
        }

        // PUT api/Task/5
        [Authorize(Roles = "Client")]
        public IHttpActionResult PutTaskViewModel(int id, TaskViewModel taskviewmodel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != taskviewmodel.TaskID)
            {
                return BadRequest();
            }

            db.Entry(taskviewmodel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskViewModelExists(id))
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

        // POST api/Task
        [ResponseType(typeof(TaskViewModel))]
        [Authorize(Roles="Client")]
        public IHttpActionResult PostTaskViewModel(TaskViewModel taskviewmodel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tasks.Add(taskviewmodel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = taskviewmodel.TaskID }, taskviewmodel);
        }

        // DELETE api/Task/5
        [Authorize(Roles = "Client")]
        [ResponseType(typeof(TaskViewModel))]
        public IHttpActionResult DeleteTaskViewModel(int id)
        {
            TaskViewModel taskviewmodel = db.Tasks.Find(id);
            if (taskviewmodel == null)
            {
                return NotFound();
            }

            db.Tasks.Remove(taskviewmodel);
            db.SaveChanges();

            return Ok(taskviewmodel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TaskViewModelExists(int id)
        {
            return db.Tasks.Count(e => e.TaskID == id) > 0;
        }
    }
}