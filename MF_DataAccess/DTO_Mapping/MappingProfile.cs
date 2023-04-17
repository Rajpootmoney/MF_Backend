using AutoMapper;
using Backend_Models.Models;
using MF_DataAccess.DTOs;
using MF_Models.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF_DataAccess.DTO_Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<CountryDTO, Country>().ReverseMap();
            CreateMap<CustomerFormDTO, CustomerForm>().ReverseMap();
            CreateMap<CustomerFormDTO2, CustomerForm>().ReverseMap();
        }

    }
}
