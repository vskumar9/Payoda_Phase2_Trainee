using API_Application.Interface;
using API_Application.Models;

namespace API_Application.Service
{
    public class CompanyService
    {
        private readonly ICompany _company;

        public CompanyService(ICompany company)
        {
            _company = company;
        }

        public async Task<IEnumerable<Company>> GetAllCompanies()
        {
            return await _company.GetAllCompanies();
        }

        public async Task<Company> GetCompany(int companyId)
        {
            return await _company.GetCompany(companyId);
        }

        public async Task AddCompany(Company company)
        {
            await _company.AddCompany(company);
        }

        public async Task UpdateCompany(int id, Company company)
        {
            await _company.UpdateCompany(id, company);
        }

        public async Task DeleteCompany(int companyId)
        {
            await _company.DeleteCompany(companyId);
        }
    }

}
