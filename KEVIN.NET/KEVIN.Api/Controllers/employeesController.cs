using KEVIN.Contract.Interfaces.Services;
using KEVIN.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace KEVIN.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class employeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public employeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> employees()
        {
            var responsePackage = await _employeeService.GetAllAsync();
            Response.StatusCode = responsePackage.StatusCode;
            return StatusCode(responsePackage.StatusCode, responsePackage);
        }

        [HttpGet]
        [Route("employee")]
        public async Task<IActionResult> employee([FromQuery] int id)
        {
            var responsePackage = await _employeeService.GetByIdAsync(id);
            Response.StatusCode = responsePackage.StatusCode;
            return StatusCode(responsePackage.StatusCode, responsePackage);
        }

        [HttpPost]
        [Route("employee")]
        public async Task<IActionResult> employee(EmployeeDto employee)
        {
            var responsePackage = await _employeeService.CreateAsync(employee);
            Response.StatusCode = responsePackage.StatusCode;
            return StatusCode(responsePackage.StatusCode, responsePackage);
        }

        [HttpPut]
        [Route("employee")]
        public async Task<IActionResult> employee(EmployeeDto employee, int id)
        {
            var responsePackage = await _employeeService.UpdateAsync(employee, id);
            Response.StatusCode = responsePackage.StatusCode;
            return StatusCode(responsePackage.StatusCode, responsePackage);
        }

        [HttpDelete]
        [Route("employee")]
        public async Task<IActionResult> employeeDelete([FromQuery] int id)
        {
            var responsePackage = await _employeeService.DeleteAsync(id);
            Response.StatusCode = responsePackage.StatusCode;
            return StatusCode(responsePackage.StatusCode, responsePackage);
        }

    }
}
