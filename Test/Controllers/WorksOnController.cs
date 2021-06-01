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
    public class WorksOnController : ControllerBase
    {
        private IGenericComposite<WorksOn> repo;

        public WorksOnController(IGenericComposite<WorksOn> repo)
        {
            this.repo = repo;
        }


        // GET: api/WorksOn
        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(200, Type = typeof(ActionResult<List<WorksOn>>))]
        public ActionResult<List<WorksOn>> Get()
        {
            var rels = repo.RetriveAll();
            if (rels.Count == 0)
            {
                return NoContent();
            }

            return Ok(rels);
        }

        // GET api/WorksOn/5/2
        [HttpGet("{id1}/{id2}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(ActionResult<WorksOn>))]
        public ActionResult<WorksOn> Get(int id1, int id2)
        {
            if (id1 <= 0 || id2 <= 0)
            {
                return BadRequest();
            }

            var rel = repo.Retrive(id1, id2);
            if (rel == null)
            {
                return NotFound();
            }

            return Ok(rel);
        }

        // GET api/WorksOn/GetByEmpId/5
        [HttpGet]
        [Route("GetByEmpId/{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(ActionResult<List<WorksOn>>))]
        public ActionResult<WorksOn> GetByEmpId(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var rel = repo.RetriveWithFstKey(id);
            if (rel == null)
            {
                return NotFound();
            }

            return Ok(rel);
        }

        // GET api/WorksOn/GetByProjId/5
        [HttpGet]
        [Route("GetByProjId/{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(ActionResult<List<WorksOn>>))]
        public ActionResult<WorksOn> GetByProjId(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var rel = repo.RetriveWithSndKey(id);
            if (rel == null)
            {
                return NotFound();
            }

            return Ok(rel);
        }

        // POST api/WorksOn
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult<WorksOn> Post([FromBody] WorksOn project)
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

        // DELETE api/WorksOn/5
        [HttpDelete]
        [Route("{id1}/{id2}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult Delete(int id1, int id2)
        {
            if (id1 <= 0 || id2 <= 0)
            {
                return BadRequest();
            }

            bool deleted = repo.Delete(id1, id2);
            if (!deleted)
            {
                return BadRequest($"Delete Failed, Please recheck keys entered!");
            }

            return NoContent();

        }

        // Put api/WorksOn/5/2
        [HttpPut]
        [Route("{id1}/{id2}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult Put(int id1, int id2, [FromBody] WorksOn rel)
        {
            if (rel == null || rel.ProjectNo <= 0 || rel.ProjectNo <= 0 || rel.EmpNo != id1 || rel.ProjectNo != id2)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var modified = repo.Put(rel);
            if (modified == null)
            {
                return BadRequest("Failed to Update!");
            }

            return NoContent();
        }
    }
}
