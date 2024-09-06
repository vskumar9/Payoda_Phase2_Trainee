using API_Application.Models;

namespace API_Application.Interface
{
    public interface ICompany
    {
        Task<IEnumerable<Company>> GetAllCompanies();
        Task<Company> GetCompany(int companyId);
        Task AddCompany(Company company);
        Task UpdateCompany(int id, Company company);
        Task DeleteCompany(int companyId);
    }
}
