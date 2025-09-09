using System.Security.Cryptography.X509Certificates;
using EmoloyeeManager.DL;

namespace EmployeeManager.BL;

public class EmployeeService : IEmployeeService
{
    private readonly ICrudDl<Employee> _employeeDl;

    public EmployeeService(ICrudDl<Employee> employeeDl)
    {
        _employeeDl = employeeDl;
    }
    
    public async Task CreateEmployee(Employee employee)
    { 
        await _employeeDl.Insert(employee);
    }
    public async Task UpdateEmployee(Employee employee)
    {
        await _employeeDl.Update(employee);
    }
    public async Task DeleteEmployee(string email)
    {
       
        await _employeeDl.Delete(email);
    }
    public async Task<Employee?> GetEmployee(string email)
    {
       return await _employeeDl.GetByEmail(email);
    }
    public async Task<List<Employee>> GetEmployees()
    {
        return await _employeeDl.GetAll();
    }
}