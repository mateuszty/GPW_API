using AutoMapper;
using GPW_API.App_Start;
using GPW_API.Core.Controllers;
using GPW_API.Core.Models;
using GPW_API.Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GPW_API.UnitTest.Core.Controllers
{
    public class GpwControllerTests
    {
        private GpwController _gpwController;
        private IMapper _mapper;
        public List<GpwCompany> _gpwCompanyList;
        private Mock<IGpwRepository> mockRepo;




        [SetUp]
        public void Setup()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapping());
            });
            _mapper = mappingConfig.CreateMapper();

            mockRepo = new Mock<IGpwRepository>();

            _gpwCompanyList = new List<GpwCompany>() { 
            new GpwCompany { Name = "aa", Abrreviation = "a", Id = 1, IsDeleated = false, MaxPrice = 1, MinPrice = 1,
                            OpeningPrice = 1, Price = 1, PriceChange = 1, PriceChangePercent = 1, RefreshTime = DateTime.Now, 
                            TransactionNumber = 1, Turnover = 1},
            new GpwCompany { Name = "bb", Abrreviation = "b", Id = 2, IsDeleated = false, MaxPrice = 1, MinPrice = 1,
                            OpeningPrice = 1, Price = 1, PriceChange = 1, PriceChangePercent = 1, RefreshTime = DateTime.Now,
                            TransactionNumber = 1, Turnover = 1},
            new GpwCompany { Name = "cc", Abrreviation = "c", Id = 3, IsDeleated = false, MaxPrice = 1, MinPrice = 1,
                            OpeningPrice = 1, Price = 1, PriceChange = 1, PriceChangePercent = 1, RefreshTime = DateTime.Now,
                            TransactionNumber = 1, Turnover = 1}};

            mockRepo.Setup(r => r.GetAllCompanies()).ReturnsAsync(_gpwCompanyList);
            mockRepo.Setup(r => r.GetCompany("a")).ReturnsAsync(_gpwCompanyList.Find(c => c.Abrreviation == "a"));
            mockRepo.Setup(r => r.GetCompany("bad abrreviation")).Returns(value: null);

            _gpwController = new GpwController(_mapper, mockRepo.Object);
        }

        [Test]
        public async Task GetGpw_NoArguments_ReturnCompanyListAsync()
        {
            var result = await _gpwController.GetGpw();

            var statusCode = (result.Result as ObjectResult).StatusCode;
            var resultValue = (result.Result as ObjectResult).Value;

            Assert.IsNotNull(result);
            Assert.AreEqual(statusCode, 200);
            Assert.IsNotNull(resultValue);
;       }

        [Test]
        public async Task GetGpw_ValidCompanyAbrreviation_ReturnCompany()
        {
            var result = await _gpwController.GetGpw("a");

            var statusCode = (result.Result as ObjectResult).StatusCode;
            var resultValue = (result.Result as ObjectResult).Value;

            Assert.IsNotNull(result);
            Assert.AreEqual(statusCode, 200);
            Assert.IsNotNull(resultValue);
        }

        [Test]
        public async Task GetGpw_NotValidCompanyAbrreviation_ReturnNotFound()
        {
            var result = await _gpwController.GetGpw("wrong abrreviation");
            var statusCode = (result.Result as NotFoundResult).StatusCode;
            Assert.IsNotNull(result);
            Assert.AreEqual(statusCode, 404);
        }
    }
}