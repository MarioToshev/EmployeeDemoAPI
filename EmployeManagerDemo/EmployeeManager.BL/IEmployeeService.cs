using EmoloyeeManager.DL;

namespace EmployeeManager.BL;

public interface IEmployeeService
{
    public Task CreateEmployee(Employee employee);
    public Task UpdateEmployee(Employee employee);
    public Task DeleteEmployee(string email);
    public Task<Employee?> GetEmployee(string email);
    public Task<List<Employee>> GetEmployees();   
}