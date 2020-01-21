using GPW_API.Core.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace GPW_API.DataAccess
{
    public static class HtmlParsing
    {

        public static async Task<List<GpwCompany>> GetGpwCompanies()
        {
            

            var stockTableHtml = GetStockTable(await HtmlDownloader.Download("https://www.bankier.pl/gielda/notowania/akcje"));

            var companyHtmlList = GetCompanyTextList("<tr>", stockTableHtml);

            List<GpwCompany> gpwCompanies = new List<GpwCompany>();

            var refreshingTime = DateTime.Now; 

            foreach (var companyHtml in companyHtmlList)
            {
                gpwCompanies.Add(new GpwCompany
                {
                    Name = GetCompanyName(companyHtml),
                    Abrreviation = GetCompanyAbbreviation(companyHtml),
                    Price = GetCompanyPrice(companyHtml),
                    PriceChange = GetCompnayPriceChange(companyHtml),
                    PriceChangePercent = GetCompnayPriceChangePercent(companyHtml),
                    OpeningPrice = GetCompanyOpeningPrice(companyHtml),
                    MaxPrice = GetCompanyMaxPrice(companyHtml),
                    MinPrice = GetCompanyMinPrice(companyHtml),
                    TransactionNumber = GetCompnayTransactionNumber(companyHtml),
                    Turnover = GetCompnayTurnover(companyHtml),
                    RefreshTime=refreshingTime
                });
            }
            return gpwCompanies;
        }


        private static string GetMiddleText(string takeFrom, string takeTo, string htmlCode)
        {
            var htmlCodeTakenFrom = htmlCode.Split(takeFrom)[1];
            var htmlCodeTakenTo = htmlCodeTakenFrom.Split(takeTo)[0];
            return htmlCodeTakenTo;
        }

        private static string GetMiddleText(string takeFrom, string takeFrom2, string takeFrom3, string takeTo, string htmlCode)
        {
            var htmlCodeTakenFromTable = htmlCode.Split(takeFrom);
            if (htmlCodeTakenFromTable.Length < 2)
                htmlCodeTakenFromTable = htmlCode.Split(takeFrom2);
            if (htmlCodeTakenFromTable.Length < 2)
                htmlCodeTakenFromTable = htmlCode.Split(takeFrom3);

            var htmlCodeTakenFrom = htmlCodeTakenFromTable[1];
            var htmlCodeTakenTo = htmlCodeTakenFrom.Split(takeTo)[0];
            return htmlCodeTakenTo;
        }

        private static string GetStockTable(string htmlCode)
        {
            return GetMiddleText("<tbody", "</tbody", htmlCode);
        }

        private static IEnumerable<string> GetCompanyTextList(string separator, string stockTable)
        {
            return stockTable.Split(separator).Skip<string>(1);
        }

        private static string GetCompanyName(string companyText)
        {
            return GetMiddleText("title=\"", "\" href", companyText);
        }

        private static string GetCompanyAbbreviation(string companyText)
        {
            return GetMiddleText("symbol=", "\">", companyText);
        }

        private static float GetCompanyPrice(string companyText)
        {
            var course = GetMiddleText("colKurs change  down\">", "colKurs change \">", "colKurs change  up\">", "</td>", companyText).Replace("&nbsp;", "");
            var style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign;
            var provider = new CultureInfo("pl-PL");
            return float.Parse(course, style, provider);
        }

        private static float GetCompanyOpeningPrice(string companyText)
        {
            var course = GetMiddleText("colOtwarcie\">", "</td>", companyText).Replace("&nbsp;", "");
            var style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign;
            var provider = new CultureInfo("pl-PL");
            return float.Parse(course, style, provider);
        }

        private static float GetCompanyMaxPrice(string companyText)
        {
            var course = GetMiddleText("calMaxi\">", "</td>", companyText).Replace("&nbsp;", "");
            var style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign;
            var provider = new CultureInfo("pl-PL");
            return float.Parse(course, style, provider);
        }

        private static float GetCompanyMinPrice(string companyText)
        {
            var course = GetMiddleText("calMini\">", "</td>", companyText).Replace("&nbsp;", "");
            var style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign;
            var provider = new CultureInfo("pl-PL");
            return float.Parse(course, style, provider);
        }

        private static float GetCompnayPriceChange(string companyText)
        {
            var courseChange = GetMiddleText("colZmiana change  down\">", "colZmiana change \">", "colZmiana change  up\">", "</td>", companyText).Replace("&nbsp;", "");
            var style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign;
            var provider = new CultureInfo("pl-PL");
            return float.Parse(courseChange, style, provider);
        }

        private static float GetCompnayPriceChangePercent(string companyText)
        {
            var percent = GetMiddleText("colZmianaProcentowa change  down\">", "colZmianaProcentowa change \">", "colZmianaProcentowa change  up\">", "</td>", companyText).Trim('%');
            var style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign;
            var provider = new CultureInfo("pl-PL");
            return float.Parse(percent, style, provider);
        }

        private static int GetCompnayTransactionNumber(string companyText)
        {
            var transactionNumber = GetMiddleText("colLiczbaTransakcji\">", "</td>", companyText).Replace("&nbsp;", "");
            return int.Parse(transactionNumber);
        }

        private static float GetCompnayTurnover(string companyText)
        {
            var turnover = GetMiddleText("colObrot\">", "</td>", companyText).Replace("&nbsp;", "");
            var style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign;
            var provider = new CultureInfo("pl-PL");
            return float.Parse(turnover, style, provider);

        }


    }
}
