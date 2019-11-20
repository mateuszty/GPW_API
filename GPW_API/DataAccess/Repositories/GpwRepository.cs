using GPW_API.Core.Models;
using GPW_API.Core.Repositories;
using GPW_API.DataAccess.References;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GPW_API.DataAccess.Repositories
{
    public class GpwRepository : IGpwRepository
    {
        private GpwContext _context { get; }

        public GpwRepository(GpwContext context)
        {
            _context = context;
        }

        public List<GpwCompany> GetAllCompanies()
        {
            return _context.gpwCompanies.ToList().OrderBy(c => c.Abrreviation).ToList();
        }

        public GpwCompany GetCompany(string abrreviation)
        {
            return _context.gpwCompanies.SingleOrDefault(c => c.Abrreviation.ToLower() == abrreviation.ToLower());
        }

        public void GpwRefresh(List<GpwCompany> companiesInStock)
        {
            var companiesInDb = _context.gpwCompanies.ToList();

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

            _context.SaveChanges();
        }
    }
}
