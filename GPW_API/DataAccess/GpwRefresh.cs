using GPW_API.Core.Models;
using GPW_API.Core.Repositories;
using GPW_API.DataAccess.References;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GPW_API.DataAccess
{
    public class GpwRefresh
    {
        private readonly IGpwRepository _repository;

        public GpwRefresh(IGpwRepository repository)
        {
            _repository = repository;
        }

        public void GpwRefreshing()
        {

            var companiesInStock = GetGpwCompanies();

            _repository.GpwRefresh(companiesInStock);

        }


    public List<GpwCompany> GetGpwCompanies()
        {
            var htmlParsing = new HtmlParsing();
            var result = htmlParsing.GetGpwCompanies();
            return result;
        }

        public void OnDataRefreshing(object source, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
