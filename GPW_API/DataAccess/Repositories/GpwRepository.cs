using GPW_API.Core.Models;
using GPW_API.Core.Repositories;
using GPW_API.DataAccess.References;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GPW_API.DataAccess.Repositories
{
    public class GpwRepository : IGpwRepository
    {
        private GpwContext _context { get; }

        public GpwRepository(GpwContext context)
        {
            _context = context;
        }

        public async Task<List<GpwCompany>> GetAllCompanies()
        {
            return await _context.gpwCompanies.OrderBy(c => c.Abrreviation).ToListAsync();
        }

        public async Task<GpwCompany> GetCompany(string abrreviation)
        {
            return await _context.gpwCompanies.SingleOrDefaultAsync(c => c.Abrreviation.ToLower() == abrreviation.ToLower());
        }

        public async Task GpwRefresh(List<GpwCompany> companiesInStock)
        {
            var companiesInDb = await _context.gpwCompanies.ToListAsync();

            foreach (var companyInDb in companiesInDb)
            {
                companyInDb.IsDeleated = true;
            }

            foreach (var companyInStock in companiesInStock)
            {
                var companyInDb = companiesInDb.SingleOrDefault(c => c.Abrreviation == companyInStock.Abrreviation);

                if (companyInDb == null)
                {
                    companyInStock.IsDeleated = false;
                    _context.gpwCompanies.Add(companyInStock);
                }
                else
                {
                    companyInDb.IsDeleated = false;
                    companyInDb.Price = companyInStock.Price;
                    companyInDb.PriceChange = companyInStock.PriceChange;
                    companyInDb.PriceChangePercent = companyInStock.PriceChangePercent;
                    companyInDb.TransactionNumber = companyInStock.TransactionNumber;
                    companyInDb.Turnover = companyInStock.Turnover;
                    companyInDb.MaxPrice = companyInStock.MaxPrice;
                    companyInDb.MinPrice = companyInStock.MinPrice;
                    companyInDb.OpeningPrice = companyInStock.OpeningPrice;
                    companyInDb.RefreshTime = companyInStock.RefreshTime;
                }

            }

            await _context.SaveChangesAsync();
        }
    }
}
