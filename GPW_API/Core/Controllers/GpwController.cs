using System.Collections.Generic;
using AutoMapper;
using GPW_API.App_Start;
using GPW_API.Core.Dtos;
using GPW_API.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GPW_API.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GpwController : ControllerBase
    {

        private IGpwRepository _repository;
        private readonly IMapper _mapper;


        MapperConfiguration mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new AutoMapping());
        });

        public GpwController(IMapper mapper, IGpwRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<GpwCompanyDto>> GetGpw()
        {
            var companies = _repository.GetAllCompanies();
            return Ok(_mapper.Map<List<GpwCompanyDto>>(companies));
        }
        [HttpGet("{abrreviation}")]
        public ActionResult<GpwCompanyDto> GetGpw(string abrreviation)
        {
            var company = _repository.GetCompany(abrreviation);

            if (company == null)
                return NotFound();

            return Ok(_mapper.Map<GpwCompanyDto>(company));
        }


    }
}
