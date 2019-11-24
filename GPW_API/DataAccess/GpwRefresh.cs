using GPW_API.Core.Models;
using GPW_API.Core.Repositories;
using GPW_API.DataAccess.References;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var htmlParsing = new HtmlParsing();
            var result = htmlParsing.GetGpwCompanies();
            return result;
        }
    }
}
