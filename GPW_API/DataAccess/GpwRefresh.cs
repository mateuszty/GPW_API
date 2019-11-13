using GPW_API.Core.ExternalResources;
using GPW_API.Core.Models;
using GPW_API.DataAccess.References;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace GPW_API.DataAccess
{
    public class GpwRefresh : IGpwRefreshcs
    {
        private GpwContext _context { get; }

        public GpwRefresh()
        {
            _context = new GpwContext();
        }

        public void GpwRefreshing()
        {
            var companiesInDb = _context.gpwCompanies.ToList();

            var companiesInStock = GetGpwCompanies();

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
