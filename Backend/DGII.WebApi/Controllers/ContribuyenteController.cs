using DGII.Common;
using DGII.Core.Application.Dtos;
using DGII.Core.Application.Interfaces.Service;
using DGII.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DGII.WebApi.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class ContribuyenteController : ControllerBase
    {
        private readonly IContribuyenteService _contribuyenteService;

        public ContribuyenteController(IContribuyenteService contribuyenteService)
        {
            _contribuyenteService = contribuyenteService;
        }


        [HttpGet]
        public async Task<ActionResult<ApiResponse>> Get()
        {
            return Ok(new ApiResponse<IEnumerable<ContribuyenteDto>>(await _contribuyenteService.Get()));
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<ApiResponse>> GetById(int id)
        {
            return Ok(new ApiResponse<ContribuyenteDto>(await _contribuyenteService.GetById(id)));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Create([FromBody] ContribuyenteDto contribuyente)
        {
            return Ok(new ApiResponse<ContribuyenteDto>(await _contribuyenteService.Create(contribuyente)));
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<ApiResponse>> Update(int id, [FromBody] ContribuyenteDto contribuyente)
        {
            return Ok(new ApiResponse<ContribuyenteDto>(await _contribuyenteService.Update(id, contribuyente)));
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<ApiResponse>> Delete(int id)
        {
            return Ok(new ApiResponse<bool>(await _contribuyenteService.Delete(id)));
        }

    }
}
