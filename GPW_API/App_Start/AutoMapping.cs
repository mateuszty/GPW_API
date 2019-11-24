using AutoMapper;
using GPW_API.Core.Dtos;
using GPW_API.Core.Models;
using System;

namespace GPW_API.App_Start
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<GpwCompany,GpwCompanyDto>();
            CreateMap<DateTime, string>().ConvertUsing(dt => dt.ToString("yyyy-MM-dd HH:mm:ss)"));
        }
    }
}
