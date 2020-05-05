using AutoMapper;
using Sla.Service.Dtos;
using Sla.WebApi.Controllers.Parameters;
using Sla.WebApi.Controllers.ViewModels;

namespace Sla.WebApi.Controllers.Infrastructure.Mapping
{
    public class ControllerProfile : Profile
    {
        public ControllerProfile()
        {
            this.CreateMap<ShipperParameter, ShipperDto>();
            this.CreateMap<ShipperDto, ShipperViewModel>();
        }
    }
}