using InterviewTest.RequestModels;
using InterviewTest.ResponseModels;
using InterviewTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetEmployeesResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            ServiceResult<GetEmployeesResponse> result = employeeService.GetEmployees();
            return result.IsSuccess ? Ok(result.Data) : NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetEmployeesResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] CreateEmployeeRequest request)
        {
            ServiceResult<GetEmployeesResponse> result = employeeService.CreateEmployee(request);
            return result.IsSuccess ? Ok(result.Data) : BadRequest();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetEmployeesResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put([FromBody] UpdateEmployeeRequest request)
        {
            ServiceResult<GetEmployeesResponse> result = employeeService.UpdateEmployee(request);
            return result.IsSuccess ? Ok(result.Data) : BadRequest();
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetEmployeesResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int Id)
        {
            ServiceResult<GetEmployeesResponse> result = employeeService.DeleteEmployee(Id);
            return result.IsSuccess ? Ok(result.Data) : BadRequest();
        }

    }
}
