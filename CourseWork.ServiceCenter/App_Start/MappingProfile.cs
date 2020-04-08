﻿using AutoMapper;
using CourseWork.ServiceCenter.Dtos;
using CourseWork.ServiceCenter.Models;

namespace CourseWork.ServiceCenter.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();

            Mapper.CreateMap<EmployeePosition, EmployeePositionDto>();
            Mapper.CreateMap<EmployeePositionDto, EmployeePosition>();

            Mapper.CreateMap<Employee, EmployeeDto>();
            Mapper.CreateMap<EmployeeDto, Employee>();

            Mapper.CreateMap<City, CityDto>();
            Mapper.CreateMap<CityDto, City>();

            Mapper.CreateMap<Models.ServiceCenter, ServiceCenterDto>();
            Mapper.CreateMap <ServiceCenterDto, Models.ServiceCenter>();




        }
    }
}