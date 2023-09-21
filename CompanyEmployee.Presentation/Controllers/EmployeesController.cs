using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEmployee.Presentation.Controllers
{
    [Route("api/companies/{companyId}/employees")]
    [ApiController]

    public class EmployeesController : ControllerBase
    {
        private readonly IServiceManager _service;

        public EmployeesController(IServiceManager service) =>
            _service = service;

        [HttpGet]
        public IActionResult GetEmployees()
        {
            //throw new Exception("Exception");
            var employees =
            _service.EmployeeService.GetAllEmployees(trackChanges: false);
            return Ok(employees);

        }
        [HttpGet("{id:guid}")]
        public IActionResult GetEmployee(Guid id)
        {
            var employee = _service.EmployeeService.GetEmployee(id, trackChanges: false);
            return Ok(employee);
        }
    }
}
