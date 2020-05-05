using AutoMapper;
using Sla.Repository.Entities;
using Sla.Service.Dtos;

namespace Sla.Service.Infrastructure.Mapping
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            this.CreateMap<Shipper, ShipperDto>();
            this.CreateMap<ShipperDto, Shipper>();
        }
    }
}