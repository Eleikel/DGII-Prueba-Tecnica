using AutoMapper;
using DGII.Common.Exceptions;
using DGII.Core.Application.Dtos;
using DGII.Core.Application.Interfaces.Repository;
using DGII.Core.Application.Interfaces.Service;
using DGII.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DGII.Core.Application.Services
{
    public class ComprobanteFiscalService : IComprobanteFiscalService
    {
        private readonly IComprobanteFiscalRepository _comprobanteFiscalRepository;
        private readonly IContribuyenteRepository _contribuyenteRepository;
        private readonly IMapper _mapper;

        public ComprobanteFiscalService(IComprobanteFiscalRepository comprobanteFiscalRepository, IContribuyenteRepository contribuyenteRepository, IMapper mapper)
        {
            _comprobanteFiscalRepository = comprobanteFiscalRepository;
            _contribuyenteRepository = contribuyenteRepository;
            _mapper = mapper;
        }

        public async Task<ComprobanteFiscalDto> Create(ComprobanteFiscalDto comprobanteFiscalDto)
        {
            var contribuyenteEntity = await _contribuyenteRepository.GetByIdAsync(comprobanteFiscalDto.ContribuyenteId) ?? throw new NotFoundException("El Contribuyente");

            ComprobanteFiscal comprobanteFiscalEntitiy = _mapper.Map<ComprobanteFiscal>(comprobanteFiscalDto);

            var itbis18Calc = Math.Round((comprobanteFiscalDto.Monto * 0.18m), 2);

            comprobanteFiscalEntitiy = new ComprobanteFiscal()
            {
                Id = comprobanteFiscalDto.Id,
                NCF = comprobanteFiscalEntitiy.NCF,
                Monto = comprobanteFiscalDto.Monto,
                Itbis18 = itbis18Calc,
                ContribuyenteId = comprobanteFiscalDto.ContribuyenteId,
                RncCedula = contribuyenteEntity.RncCedula
            };

            comprobanteFiscalEntitiy = await _comprobanteFiscalRepository.CreateAsync(comprobanteFiscalEntitiy);
            var comprobanteFiscalToDto = _mapper.Map<ComprobanteFiscalDto>(comprobanteFiscalEntitiy);
            return comprobanteFiscalToDto;
        }

        public async Task<bool> Delete(int id)
        {
            var comprobanteFiscalEntity = await _comprobanteFiscalRepository.GetByIdAsync(id) ?? throw new NotFoundException("El comprobante fiscal");
            var comprobanteFiscalDeleted = await _comprobanteFiscalRepository.DeleteAsync(comprobanteFiscalEntity);
            return comprobanteFiscalDeleted;
        }

        public async Task<IEnumerable<ComprobanteFiscalDto>> Get()
        {
            var propertiesToInclude = new List<string> { "Contribuyente" };

            var comprobanteFiscalEntities = await _comprobanteFiscalRepository.GetAllWithIncludeAsync(propertiesToInclude);
            var comprobanteFiscalDto = _mapper.Map<IEnumerable<ComprobanteFiscalDto>>(comprobanteFiscalEntities) ?? throw new NotFoundException();
            return comprobanteFiscalDto;
        }

        public async Task<ComprobanteFiscalDto> GetById(int id)
        {
            var comprobanteFiscalEntity = await _comprobanteFiscalRepository.GetByIdAsync(id) ?? throw new NotFoundException("El comprobante fiscal");
            var comprobanteFiscalDto = _mapper.Map<ComprobanteFiscalDto>(comprobanteFiscalEntity);
            return comprobanteFiscalDto;
        }

        public async Task<ComprobanteFiscalDto> Update(int id, ComprobanteFiscalDto comprobanteFiscalDto)
        {

            var comprobanteFiscalEntity = await _comprobanteFiscalRepository.GetByIdAsync(id) ?? throw new NotFoundException("El comprobante fiscal");

            if (comprobanteFiscalEntity.Monto != comprobanteFiscalDto.Monto)
            {
                var itbis18Calc = Math.Round((comprobanteFiscalDto.Monto * 0.18m), 2);

                comprobanteFiscalEntity.Itbis18 = itbis18Calc;
            }

            comprobanteFiscalEntity.NCF = comprobanteFiscalDto.NCF;
            comprobanteFiscalEntity.Monto = comprobanteFiscalDto.Monto;
            comprobanteFiscalEntity.ContribuyenteId = comprobanteFiscalDto.ContribuyenteId;

            await _comprobanteFiscalRepository.UpdateAsync(comprobanteFiscalEntity, id);

            return await GetById(id);

        }

    }
}
