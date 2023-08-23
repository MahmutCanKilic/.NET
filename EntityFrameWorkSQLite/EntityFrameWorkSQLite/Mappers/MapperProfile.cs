using AutoMapper;
using Data.Dto;
using Data.Entity;

namespace EntityFrameWorkSQLite.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateCarDto, Car>().ForMember(dto => dto.Price, car => car.MapFrom(x => x.Price));
            CreateMap<CreateBusDto, Bus>();
            CreateMap<CreateCustomerDto, Customer>();
            CreateMap<Car, CreateCarDto>();
            CreateMap<Bus, CreateBusDto>();
            CreateMap<Customer, CreateCustomerDto>();
        }
    }
}
