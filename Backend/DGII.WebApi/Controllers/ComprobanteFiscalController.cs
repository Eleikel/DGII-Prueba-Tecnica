using DGII.Common;
using DGII.Core.Application.Dtos;
using DGII.Core.Application.Interfaces.Service;
using DGII.Core.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DGII.WebApi.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class ComprobanteFiscalController : ControllerBase
    {
        private readonly IComprobanteFiscalService _comprobanteFiscalService;

        public ComprobanteFiscalController(IComprobanteFiscalService comprobanteFiscalService)
        {
            _comprobanteFiscalService = comprobanteFiscalService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> Get()
        {
            return Ok(new ApiResponse<IEnumerable<ComprobanteFiscalDto>>(await _comprobanteFiscalService.Get()));
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<ApiResponse>> GetById(int id)
        {
            return Ok(new ApiResponse<ComprobanteFiscalDto>(await _comprobanteFiscalService.GetById(id)));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Create([FromBody] ComprobanteFiscalDto comprobanteFiscal)
        {
            return Ok(new ApiResponse<ComprobanteFiscalDto>(await _comprobanteFiscalService.Create(comprobanteFiscal)));
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<ApiResponse>> Update(int id, [FromBody] ComprobanteFiscalDto comprobanteFiscal)
        {
            return Ok(new ApiResponse<ComprobanteFiscalDto>(await _comprobanteFiscalService.Update(id, comprobanteFiscal)));
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<ApiResponse>> Delete(int id)
        {
            return Ok(new ApiResponse<bool>(await _comprobanteFiscalService.Delete(id)));
        }

    }
}
