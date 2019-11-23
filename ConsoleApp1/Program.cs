using AutoMapper;
using GPW_API.App_Start;
using GPW_API.Core.Controllers;
using GPW_API.Core.Dtos;
using GPW_API.Core.Models;
using GPW_API.Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {



        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


        var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapping());
            });
            var _mapper = mappingConfig.CreateMapper();

            var mockRepo = new Mock<IGpwRepository>();

            var _gpwCompanyList = new List<GpwCompany>() {
            new GpwCompany { Name = "aa", Abrreviation = "a", Id = 1, IsDeleated = false, MaxPrice = 1, MinPrice = 1,
                            OpeningPrice = 1, Price = 1, PriceChange = 1, PriceChangePercent = 1, RefreshTime = DateTime.Now,
                            TransactionNumber = 1, Turnover = 1},
            new GpwCompany { Name = "bb", Abrreviation = "b", Id = 2, IsDeleated = false, MaxPrice = 1, MinPrice = 1,
                            OpeningPrice = 1, Price = 1, PriceChange = 1, PriceChangePercent = 1, RefreshTime = DateTime.Now,
                            TransactionNumber = 1, Turnover = 1},
            new GpwCompany { Name = "cc", Abrreviation = "c", Id = 3, IsDeleated = false, MaxPrice = 1, MinPrice = 1,
                            OpeningPrice = 1, Price = 1, PriceChange = 1, PriceChangePercent = 1, RefreshTime = DateTime.Now,
                            TransactionNumber = 1, Turnover = 1}};

            mockRepo.Setup(r => r.GetAllCompanies()).Returns(_gpwCompanyList);
            mockRepo.Setup(r => r.GetCompany("a")).Returns(_gpwCompanyList.Find(c => c.Abrreviation == "a"));
            //mockRepo.Setup(r => r.GetCompany("bad abrreviation")).Returns(value: null);

            var _gpwController = new GpwController(_mapper, mockRepo.Object);



            var result = _gpwController.GetGpw();

            var statusCode = (result.Result as ObjectResult)?.StatusCode;
            var resultValue = Convert.ChangeType((result.Result as ObjectResult)?.Value, typeof(List<GpwCompanyDto>));

            var companies1 = _mapper.Map<List<GpwCompanyDto>>(_gpwCompanyList);

            var companies2 = resultValue;

            foreach (var company in companies1)
            {
                Console.WriteLine(company.Name);
            }

        }
    }
}
