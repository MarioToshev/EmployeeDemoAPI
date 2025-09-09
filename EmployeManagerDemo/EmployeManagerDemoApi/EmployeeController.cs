using EmoloyeeManager.DL;
using EmployeeManager.BL;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EmployeManagerDemoAPI;


[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }
    
    [HttpGet]
    public async Task<IEnumerable<Employee>> GetAll()
    {
        return await _employeeService.GetEmployees();
    }
    
    [HttpGet("{email}")]
    public async Task<Employee> GetAll(string email)
    {
        return await _employeeService.GetEmployee(email)!??new Employee();;
    }
    
    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody]Employee? employee)
    {
        if (employee == null)
        {
            return BadRequest("Employee data is required.");
        }
        try
        {
            await _employeeService.UpdateEmployee(employee);

        }
        catch (Exception e)
        {
            Console.WriteLine("An error occured: " + e.Message );
            return BadRequest(e.Message);
        }
        return Ok("Employee updated");    
    }
    [HttpPost("create")]
    public async Task<IActionResult> CreateEmployee([FromBody]Employee? employee)
    {
        if (employee == null)
        {
            return BadRequest("Employee data is required.");
        }
        try
        {
            await _employeeService.CreateEmployee(employee);
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occured: " + e.Message );
            return BadRequest(e.Message);
        }
        return Ok("Employee Created");    
    }
    [HttpDelete("delete/{email}")]
    public async Task<IActionResult> Delete(string email)
    {
        if (string.IsNullOrWhiteSpace(email.Trim()))
        {
            return BadRequest("Employee data is required.");
        }
        try
        {
            await _employeeService.DeleteEmployee(email.Trim());
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occured: " + e.Message );
            return BadRequest(e.Message);
        }
        return Ok("Employee deleted");    
    }
}