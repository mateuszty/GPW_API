﻿using GPW_API.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GPW_API.Core.Repositories
{
    public interface IGpwRepository
    {
        public Task<List<GpwCompany>> GetAllCompanies();

        public Task<GpwCompany> GetCompany(string abrreviation);

        public Task GpwRefresh(List<GpwCompany> companiesInStock);
    }
}
