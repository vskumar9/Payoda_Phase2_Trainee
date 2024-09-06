using API_Application.Interface;
using API_Application.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace API_Application.Repository
{
    public class EmployeeRepository : IEmployee
    {
        private readonly APIDbContext _context;

        public EmployeeRepository(APIDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _context.Employees.Include(c => c.Company).ToListAsync();
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            return await _context.Employees.Include(c => c.Company).FirstOrDefaultAsync(e => e.EmployeeId == employeeId) ?? throw new NullReferenceException();
        }
        
        public async Task AddEmployee(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployee(int id, Employee employee)
        {
            if(id == employee.EmployeeId)
            {
                _context.Entry(employee).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteEmployee(int employeeId)
        {
            var employee = await _context.Employees.FindAsync(employeeId);
            if(employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }
    }
}
