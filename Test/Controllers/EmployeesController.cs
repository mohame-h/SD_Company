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
    public class EmployeesController : ControllerBase
    {
        private IGeneric<Employee> repo;
        private IGeneric<Department> repoDept;

        public EmployeesController(IGeneric<Employee> repo, IGeneric<Department> repoDept)
        {
            this.repo = repo;
            this.repoDept = repoDept;
        }


        // GET: api/Employees
        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(200, Type = typeof(ActionResult<List<Employee>>))]
        public ActionResult<List<Employee>> Get()
        {
            var employees = repo.RetriveAll();
            if (employees.Count == 0)
            {
                return NoContent();
            }

            return Ok(employees);
        }

        // GET api/Employees/5
        [HttpGet("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(ActionResult<List<Employee>>))]
        public ActionResult<Employee> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var employee = repo.Retrive(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // POST api/Employees
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult<Employee> Post([FromBody] Employee employee)
        {
            if (employee == null || employee.DeptNo < 0)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dept = repoDept.Retrive((int)employee.DeptNo);
            if (dept == null)
            {
                return BadRequest();
            }

            var added = repo.Create(employee);
            if (added == null)
            {
                return BadRequest();
            }

            return Ok();
        }

        // DELETE api/Employees/5
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

        // Put api/Employees/5
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult Put(int id, [FromBody] Employee employee)
        {
            if (employee == null || employee.DeptNo <= 0 || employee.EmpNo <= 0 || employee.EmpNo != id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var modified = repo.Put(employee);
            if (modified == null)
            {
                return BadRequest("Failed to Update!");
            }

            return NoContent();
        }
    }
}
