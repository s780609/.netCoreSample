using AutoMapper;
using Sla.Repository.Entities;
using Sla.Repository.Interface;
using Sla.Service.Dtos;
using Sla.Service.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sla.Service.Implement
{
    public class ShipperService : IShipperService
    {
        private readonly IMapper _mapper;

        private readonly IShipperRepository _shipperRepository;

        public ShipperService(
            IMapper mapper,
            IShipperRepository shipperRepository)
        {
            this._mapper = mapper;
            this._shipperRepository = shipperRepository;
        }

        public async Task<int> AddAsync(ShipperDto dto)
        {
            if (dto is null)
            {
                throw new ArgumentNullException($"{nameof(dto)} 不可為 null");
            }

            var shipper = this._mapper.Map<Shipper>(dto);

            var count = await this._shipperRepository.AddAsync(shipper);

            return count;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var shipper = await this._shipperRepository.GetAsync(id);

            var count = await this._shipperRepository.DeleteAsync(shipper);

            return count;
        }

        public async Task<IEnumerable<ShipperDto>> GetAsync()
        {
            var shippers = await this._shipperRepository.GetAsync();

            var shipperDtos = this._mapper.Map<IEnumerable<ShipperDto>>(shippers);

            return shipperDtos;
        }

        public async Task<ShipperDto> GetAsync(int id)
        {
            var shipper = await this._shipperRepository.GetAsync(id);

            var shipperDto = this._mapper.Map<ShipperDto>(shipper);

            return shipperDto;
        }

        public async Task<int> UpdateAsync(ShipperDto dto)
        {
            if (dto is null)
            {
                throw new ArgumentNullException($"{nameof(dto)} 不可為 null");
            }

            var shipperDto = this._mapper.Map<Shipper>(dto);

            var count = await this._shipperRepository.UpdateAsync(shipperDto);

            return count;
        }
    }
}