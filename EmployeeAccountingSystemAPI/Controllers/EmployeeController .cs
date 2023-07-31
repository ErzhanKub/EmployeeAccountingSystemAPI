using EmployeeAccountingSystemAPI.Date.Models;
using EmployeeAccountingSystemAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;

namespace EmployeeAccountingSystemAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("employeeController")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeManagement _employeeManagement;

        public EmployeeController(EmployeeManagement employeeManagement)
        {
            _employeeManagement = employeeManagement;
        }

        [HttpPost]
        [SwaggerOperation("Добовляет пользователя.")]
        public IActionResult AddEmployee(Employee employee)
        {
            _employeeManagement.AddEmployee(employee);
            return Ok();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation("Удаляет пользователя по id.")]
        public IActionResult RemoveEmployee(int id)
        {
            _employeeManagement.RemoveEmployee(id);
            return Ok();
        }

        [HttpGet]
        [SwaggerOperation("Возвращает всех пользователей.")]
        public IActionResult GetAllEmployees()
        {
            var employees = _employeeManagement.GetAllEmployees();
            return Ok(employees);
        }
    }
}