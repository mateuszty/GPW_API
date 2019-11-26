using GPW_API.Core.Models;
using GPW_API.Core.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GPW_API.DataAccess
{
    public class GpwRefresh
    {
        private readonly IGpwRepository _repository;

        public GpwRefresh(IGpwRepository repository)
        {
            _repository = repository;
        }

        public async Task GpwRefreshing()
        {

            var companiesInStock = await GetGpwCompanies();

            await _repository.GpwRefresh(companiesInStock);

        }


    public Task<List<GpwCompany>> GetGpwCompanies()
        {
            var result = HtmlParsing.GetGpwCompanies();
            return result;
        }
    }
}
