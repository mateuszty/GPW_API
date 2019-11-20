using AutoMapper;
using GPW_API.App_Start;
using GPW_API.Core.Controllers;
using NUnit.Framework;

namespace GPW_API.UnitTest.Core.Controllers
{
    public class GpwControllerTests
    {
        private GpwController _gpwController;


        [SetUp]
        public void Setup()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapping());
            });
            var mapper = mappingConfig.CreateMapper();


          //  _gpwController = new GpwController(mapper, GpwContext context)
        }

        [Test]
        public void GetGpw_NoArguments_ReturnCompanyList()
        {
            Assert.Pass();
        }

        [Test]
        public void GetGpw_ValidCompanyAbrreviation_ReturnCompany()
        {
            Assert.Pass();
        }

        [Test]
        public void GetGpw_NotValidCompanyAbrreviation_ReturnNotFound()
        {
            Assert.Pass();
        }
    }
}