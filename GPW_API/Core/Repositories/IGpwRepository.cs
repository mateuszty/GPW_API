using GPW_API.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GPW_API.Core.Repositories
{
    public interface IGpwRepository
    {
        public List<GpwCompany> GetAllCompanies();

        public GpwCompany GetCompany(string abrreviation);

        public void GpwRefresh(List<GpwCompany> companiesInStock);
    }
}
