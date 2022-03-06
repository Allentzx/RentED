using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CE.Application.SpecificS;
using CE.ViewModel.SpecificA;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ccElectricRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecificController : ControllerBase
    {
        private readonly ISpecificService _specifictService;
        public SpecificController(ISpecificService specificService)
        {
            _specifictService = specificService;
        }

        [HttpPost("{productId}")]
        public async Task<IActionResult> Create(int productId, [FromBody] SpecificCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _specifictService.Create(productId, request);
            if (!result.IsSuccessed)
            {
                return StatusCode(StatusCodes.Status403Forbidden, result);
            }
            return Ok(result);
        }

        [HttpPut("{specId}")]
        public async Task<IActionResult> Update(int specId, [FromBody] SpecificUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _specifictService.Update(specId, request);
            if (!result.IsSuccessed)
            {
                return StatusCode(StatusCodes.Status403Forbidden, result);
            }
            return Ok(result);
        }
        [HttpDelete("{specId}")]
        public async Task<IActionResult> Delete(int specId)
        {
            var result = await _specifictService.Delete(specId);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
