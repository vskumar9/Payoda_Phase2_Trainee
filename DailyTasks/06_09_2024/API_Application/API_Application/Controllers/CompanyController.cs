using API_Application.Models;
using API_Application.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class CompanyController : ControllerBase
    {
        private readonly CompanyService _service;

        public CompanyController(CompanyService service)
        {
            _service = service;
        }

        // GET: api/<CompanyController>
        [HttpGet]
        public async Task<IEnumerable<Company>> Get()
        {
            return await _service.GetAllCompanies();
        }

        // GET api/<CompanyController>/5
        [HttpGet("{id}")]
        public async Task<Company> Get(int id)
        {
            return await _service.GetCompany(id);
        }

        // POST api/<CompanyController>
        [HttpPost]
        public async Task Post(Company company)
        {
            await _service.AddCompany(company);
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, Company company)
        {
            await _service.UpdateCompany(id, company);
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.DeleteCompany(id);
        }
    }
}
