using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sla.Service.Dtos;
using Sla.Service.Interface;
using Sla.WebApi.Controllers.Parameters;
using Sla.WebApi.Controllers.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sla.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly IShipperService _shipperService;

        public ShipperController(
            IMapper mapper,
            IShipperService shipperService)
        {
            this._mapper = mapper;
            this._shipperService = shipperService;
        }

        [HttpPost]
        public async Task AddAsync(ShipperParameter parameter)
        {
            if (parameter is null)
            {
                throw new ArgumentNullException($"{nameof(parameter)} 不可為 null");
            }

            var shipperDto = this._mapper.Map<ShipperDto>(parameter);

            await this._shipperService.AddAsync(shipperDto);
        }

        [HttpGet]
        public async Task<IEnumerable<ShipperViewModel>> GetAsync()
        {
            var shipperDtos = await this._shipperService.GetAsync();

            var shipperViewModels = this._mapper.Map<IEnumerable<ShipperViewModel>>(shipperDtos);

            return shipperViewModels;
        }

        [HttpGet("{id}")]
        public async Task<ShipperViewModel> GetAsync(int id)
        {
            var shipperDto = await this._shipperService.GetAsync(id);

            var shipperViewModel = this._mapper.Map<ShipperViewModel>(shipperDto);

            return shipperViewModel;
        }

        [HttpPatch]
        public async Task UpdateAsync(ShipperParameter parameter)
        {
            if (parameter is null)
            {
                throw new ArgumentNullException($"{nameof(parameter)} 不可為 null");
            }

            if (await this._shipperService.GetAsync(parameter.ShipperID) is null)
            {
                throw new ArgumentNullException($"找不到 ShipperID = {parameter.ShipperID} 的資料");
            }

            var shipperDto = this._mapper.Map<ShipperDto>(parameter);

            await this._shipperService.UpdateAsync(shipperDto);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await this._shipperService.DeleteAsync(id);
        }
    }
}