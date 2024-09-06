using API_Application.Interface;
using API_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Application.Repository
{
    public class CompanyRepository : ICompany
    {
        private readonly APIDbContext _context;

        public CompanyRepository(APIDbContext context)
        {
            _context = context;
        }

        public async Task AddCompany(Company company)
        {
            await _context.AddAsync(company);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCompany(int companyId)
        {
            var company = await _context.Companies.FindAsync(companyId);
            if (company != null)
            {
                _context.Companies.Remove(company);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Company>> GetAllCompanies()
        {
            return await _context.Companies.Include(e => e.Employees).ToListAsync();
        }

        public async Task<Company> GetCompany(int companyId)
        {
            return await _context.Companies.Include(e => e.Employees).FirstOrDefaultAsync(c => c.CompanyId == companyId) ?? throw new NullReferenceException();
        }

        public async Task UpdateCompany(int id, Company company)
        {
            if(id == company.CompanyId)
            {
                _context.Entry(company).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }
}
