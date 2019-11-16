using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GPW_API.App_Start;
using GPW_API.Core.Dtos;
using GPW_API.Core.Models;
using GPW_API.DataAccess.References;
using Microsoft.AspNetCore.Mvc;

namespace GPW_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GpwController : ControllerBase
    {

        private GpwContext _context;
        private readonly IMapper _mapper;


        MapperConfiguration mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new AutoMapping());
        });

        public GpwController(IMapper mapper, GpwContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<GpwCompany>> GetGpw()
        {
            var companies = _context.gpwCompanies.ToList().OrderBy(c => c.Abrreviation);
            return Ok(_mapper.Map<List<GpwCompanyDto>>(companies));
        }
        [HttpGet("{abrreviation}")]
        public ActionResult<GpwCompany> GetGpw(string abrreviation)
        {
            var company = _context.gpwCompanies.SingleOrDefault(c => c.Abrreviation.ToLower() == abrreviation.ToLower());

            if (company == null)
                return NotFound();

            return Ok(_mapper.Map<GpwCompanyDto>(company));
        }


    }
}
