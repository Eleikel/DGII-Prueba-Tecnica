using AutoMapper;
using DGII.Common.Exceptions;
using DGII.Core.Application.Dtos;
using DGII.Core.Application.Interfaces.Repository;
using DGII.Core.Application.Interfaces.Service;
using DGII.Core.Domain.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.Core.Application.Services
{
    public class ContribuyenteService : IContribuyenteService
    {
        private readonly IContribuyenteRepository _contribuyenteRepository;
        private readonly IMapper _mapper;

        public ContribuyenteService(IContribuyenteRepository contribuyenteRepository, IMapper mapper)
        {
            _contribuyenteRepository = contribuyenteRepository;
            _mapper = mapper;

        }
        public async Task<ContribuyenteDto> Create(ContribuyenteDto entity)
        {
            Contribuyente contribuyenteEntitiy = _mapper.Map<Contribuyente>(entity);
            contribuyenteEntitiy = await _contribuyenteRepository.CreateAsync(contribuyenteEntitiy);
            var contribuyenteDto = _mapper.Map<ContribuyenteDto>(contribuyenteEntitiy);
            return contribuyenteDto;
        }

        public async Task<bool> Delete(int id)
        {
            var contribuyenteEntity = await _contribuyenteRepository.GetByIdAsync(id) ?? throw new NotFoundException("El Contribuyente");
            var contribuyenteDeleted = await _contribuyenteRepository.DeleteAsync(contribuyenteEntity);
            return contribuyenteDeleted;
        }

        public async Task<IEnumerable<ContribuyenteDto>> Get()
        {
            var propertiesToInclude = new List<string> { "ComprobantesFiscales" };

            var contribuyenteEntities = await _contribuyenteRepository.GetAllWithIncludeAsync(propertiesToInclude);
            var contribuyenteDto = _mapper.Map<IEnumerable<ContribuyenteDto>>(contribuyenteEntities) ?? throw new NotFoundException();
            return contribuyenteDto;
        }

        public async Task<ContribuyenteDto> GetById(int id)
        {
            var contribuyenteEntity = await _contribuyenteRepository.GetByIdAsync(id) ?? throw new NotFoundException("El Contribuyente");
            var contribuyenteDto = _mapper.Map<ContribuyenteDto>(contribuyenteEntity);
            return contribuyenteDto;
        }

        public async Task<ContribuyenteDto> Update(int id, ContribuyenteDto contribuyenteDto)
        {
            var contribuyenteEntity = await _contribuyenteRepository.GetByIdAsync(id) ?? throw new NotFoundException("El Contribuyente");
            await _contribuyenteRepository.UpdateAsync(_mapper.Map<Contribuyente>(contribuyenteDto), id);
            return await GetById(id);
        }
    }
}
