using Microsoft.EntityFrameworkCore;

namespace EmoloyeeManager.DL;

public class EmployeeDl : ICrudDl<Employee>
{
    private readonly AppDbContext _context;

    public EmployeeDl(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Employee> Insert(Employee emp)
    {
        await _context.Employees.AddAsync(emp);
        await _context.SaveChangesAsync();
        return emp;
    }

    public async Task<Employee> Update(Employee emp)
    {
         _context.Employees.Update(emp);
        await _context.SaveChangesAsync();
        return emp;
    }

    public async Task Delete(string email)
    {
        var employee = await _context.Employees.FindAsync(email.Trim());

        if (employee == null)
            throw new Exception("No such employee");

        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();
    }

    public async Task <List<Employee>> GetAll()
    {
        return await _context.Employees.ToListAsync();
    }

    public async Task<Employee?> GetByEmail(string email)
    {
       return await _context.Employees.FindAsync(email);
    }
}