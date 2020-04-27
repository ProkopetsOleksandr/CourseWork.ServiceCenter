using AutoMapper;
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

            Mapper.CreateMap<Brand, BrandDto>();
            Mapper.CreateMap<BrandDto, Brand>();

            Mapper.CreateMap<ServiceType, ServiceTypeDto>();
            Mapper.CreateMap<ServiceTypeDto, ServiceType>();

            Mapper.CreateMap<DeviceType, DeviceTypeDto>();
            Mapper.CreateMap<DeviceTypeDto, DeviceType>();

            Mapper.CreateMap<PartCategory, PartCategoryDto>();
            Mapper.CreateMap<PartCategoryDto, PartCategory>();

            Mapper.CreateMap<Part, PartDto>();
            Mapper.CreateMap<PartDto, Part>();

            Mapper.CreateMap<ServiceAppliance, ServiceApplianceDto>();
            Mapper.CreateMap<ServiceApplianceDto, ServiceAppliance>();

            Mapper.CreateMap<Order, OrderDto>();
            Mapper.CreateMap<OrderDto, Order>();

            Mapper.CreateMap<PartInServiceCenter, PartInServiceCenterDto>();
            Mapper.CreateMap<PartInServiceCenterDto, PartInServiceCenter>();

            Mapper.CreateMap<ServiceCenterBrand, ServiceCenterBrandDto>();
            Mapper.CreateMap<ServiceCenterBrandDto, ServiceCenterBrand>();

            Mapper.CreateMap<ServiceCenterDeviceType, ServiceCenterDeviceTypeDto>();
            Mapper.CreateMap<ServiceCenterDeviceTypeDto, ServiceCenterDeviceType>();

            Mapper.CreateMap<OrderService, OrderServiceDto>();
            Mapper.CreateMap<OrderServiceDto, OrderService>();

            Mapper.CreateMap<OrderFulfillment, OrderFulfillmentDto>();
            Mapper.CreateMap<OrderFulfillmentDto, OrderFulfillment>();

            Mapper.CreateMap<ServiceDetails, ServiceDetailsDto>();
            Mapper.CreateMap<ServiceDetailsDto, ServiceDetails>();
        }
    }
}