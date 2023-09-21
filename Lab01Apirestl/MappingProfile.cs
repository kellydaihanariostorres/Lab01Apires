using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab01Apirestl
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>()
                .ForCtorParam("FullAddress",
                opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));

            CreateMap<Employee, EmployeeDto>();
        }
    }
}
