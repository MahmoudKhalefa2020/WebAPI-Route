using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Entities;
using Talabat.Core.Repositories;
using Talabat.Core.Specifications.EmployeeSpecs;

namespace Talabat.APIs.Controllers
{

    public class EmployeeController : BaseApiController
    {
        private readonly IGenericRepository<Employee> _employeeRepo;

        public EmployeeController(IGenericRepository<Employee> employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
        {
            var specs = new EmployeeWithDepartmentSpecifications();
            var employees = await _employeeRepo.GetAllWithSpecAsync(specs);
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var specs = new EmployeeWithDepartmentSpecifications(id);
            var employee = await _employeeRepo.GetWithSpecAsync(specs);
            if (employee is null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

    }
}
