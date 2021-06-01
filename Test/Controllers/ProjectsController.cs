using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Test.IServices;
using Test.Models;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private IGeneric<Project> repo;

        public ProjectsController(IGeneric<Project> repo)
        {
            this.repo = repo;
        }


        // GET: api/Projects
        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(200, Type = typeof(ActionResult<List<Project>>))]
        public ActionResult<List<Project>> Get()
        {
            var projects = repo.RetriveAll();
            if (projects.Count == 0)
            {
                return NoContent();
            }

            return Ok(projects);
        }

        // GET api/Projects/5
        [HttpGet("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(ActionResult<List<Project>>))]
        public ActionResult<Project> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var project = repo.Retrive(id);
            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        // POST api/Projects
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult<Project> Post([FromBody] Project project)
        {
            if (project == null || project.ProjectNo < 0)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var added = repo.Create(project);
            if (added == null)
            {
                return BadRequest();
            }

            return Ok();
        }

        // DELETE api/Projects/5
        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            bool deleted = repo.Delete(id);
            if (deleted)
            {
                return NoContent();
            }
            else
            {
                return BadRequest($"Delete Failed!");
            }

        }

        // Put api/Projects/5
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult Put(int id, [FromBody] Project project)
        {
            if (project == null || project.ProjectNo <= 0 || project.ProjectNo != id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var modified= repo.Put(project);
            if (modified == null)
            {
                return BadRequest("Failed to Update!");
            }

            return NoContent();
        }
    }
}
