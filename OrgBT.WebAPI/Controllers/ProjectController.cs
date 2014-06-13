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
    [RoutePrefix("api/Project")]
    public class ProjectController : ApiController
    {
        private TimeContext db = new TimeContext();

        // GET api/Project
        public IQueryable<ProjectViewModel> GetProjects()
        {
            return db.Projects;
        }

        //GET api/Project/5
        [ResponseType(typeof(ProjectViewModel))]
        public IHttpActionResult GetProjectViewModel(int id)
        {
            ProjectViewModel projectviewmodel = db.Projects.Find(id);
            if (projectviewmodel == null)
            {
                return NotFound();
            }
            return Ok(projectviewmodel);
        }

        // GET api/Project/Tasks?projectID=1
        [Route("Tasks")]
        public IQueryable<TaskViewModel> GetTasksByProjectID(int projectID)
        {
            // Join Tasks entity to get related tasks to the given project id
            var tasks = (from proj in db.Projects
                         join projTasks in db.Tasks
                         on proj.ProjectID equals projTasks.ProjectID
                         where proj.ProjectID == projectID
                         select projTasks).Take(100);
            return tasks;            
            
        }
        // PUT api/Project/5
        [Authorize(Roles="Client")]
        public IHttpActionResult PutProjectViewModel(int id, ProjectViewModel projectviewmodel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != projectviewmodel.ProjectID)
            {
                return BadRequest();
            }

            db.Entry(projectviewmodel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectViewModelExists(id))
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

        // POST api/Project
        [Authorize(Roles = "Client")]
        [ResponseType(typeof(ProjectViewModel))]
        public IHttpActionResult PostProjectViewModel(ProjectViewModel projectviewmodel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Projects.Add(projectviewmodel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = projectviewmodel.ProjectID }, projectviewmodel);
        }

        // DELETE api/Project/5
        [Authorize(Roles = "Client")]
        [ResponseType(typeof(ProjectViewModel))]
        public IHttpActionResult DeleteProjectViewModel(int id)
        {
            ProjectViewModel projectviewmodel = db.Projects.Find(id);
            if (projectviewmodel == null)
            {
                return NotFound();
            }

            db.Projects.Remove(projectviewmodel);
            db.SaveChanges();

            return Ok(projectviewmodel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProjectViewModelExists(int id)
        {
            return db.Projects.Count(e => e.ProjectID == id) > 0;
        }
    }
}