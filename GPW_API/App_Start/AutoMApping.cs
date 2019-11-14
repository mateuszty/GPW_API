using AutoMapper;
using GPW_API.Core.Dtos;
using GPW_API.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GPW_API.App_Start
{
    public class AutoMApping : Profile
    {
        public AutoMApping()
        {
            CreateMap<GpwCompany,GpwCompanyDto>();
        }
    }
}
