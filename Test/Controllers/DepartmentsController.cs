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
    public class DepartmentsController : ControllerBase
    {
        private IGeneric<Department> repo;

        public DepartmentsController(IGeneric<Department> repo)
        {
            this.repo = repo;
        }


        // GET: api/Departments
        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(200, Type = typeof(ActionResult<List<Department>>))]
        public ActionResult<List<Department>> Get()
        {
            var departments = repo.RetriveAll();
            if (departments.Count == 0)
            {
                return NoContent();
            }

            return Ok(departments);
        }

        // GET api/Departments/5
        [HttpGet("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(ActionResult<List<Department>>))]
        public ActionResult<Department> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var department = repo.Retrive(id);
            if (department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }

        // POST api/Department
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult<Department> Post([FromBody] Department department)
        {
            if (department == null || department.DeptNo < 0)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var added = repo.Create(department);
            if (added == null)
            {
                return BadRequest();
            }

            return Ok();
        }

        // DELETE api/Departments/5
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

        // Put api/Departments/5
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult Put(int id, [FromBody] Department department)
        {
            if (department == null || department.DeptNo <= 0 || department.DeptNo != id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var modified= repo.Put(department);
            if (modified == null)
            {
                return BadRequest("Failed to Update!");
            }

            return NoContent();
        }
    }
}
