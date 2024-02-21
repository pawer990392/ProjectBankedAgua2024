using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WaterSystem.Application.Dtos.Request;
using WaterSystem.Application.Interfaces;
using WaterSystem.Infrastructure.Commons.Bases.Request;

namespace WaterSystem.Api.Controllers
{
    //Puse mi noMBRE MIGUEL ANGEL AJAJAJ
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SettlementController : ControllerBase
    {
        private readonly ISettlementApplication _settlementApplication;

        public SettlementController(ISettlementApplication settlementApplication)
        {
            this._settlementApplication = settlementApplication;
        }

        [HttpPost]
        public async Task<IActionResult> GetSettlmentiesFilters([FromBody] BaseFiltersRequest filtersRequest)
        {
            var response = await _settlementApplication.ListSettlmenties(filtersRequest);
            return Ok(response);
        }

        [HttpGet("Select")]
        public async Task<IActionResult> GetSettlements()
        {
            var response = await _settlementApplication.ListSelectSettlmenties();
            return Ok(response);
        }
        [HttpPost("RegistarSettlement")]
        public async Task<IActionResult> RegistrarSettlement([FromBody] SettlementRequestDto requestDto)
        {
            var response = await _settlementApplication.RegisterSettlement(requestDto);
            return Ok(response);
        }
        [HttpGet("{SettlementId}")]

        public async Task<IActionResult>SettlementById(int SettlementId)
        {
            var response = await _settlementApplication.SettlmentById(SettlementId);
            return Ok(response);
        }

        [HttpPut("Update/{SettlementId}")]
        public async Task<IActionResult> UpdateSettlemet(int SettlementId,SettlementRequestDto requestDto)
        {
            var response = await _settlementApplication.UpdateSettlement(SettlementId, requestDto);
            return Ok(response);
        }
        [HttpDelete("Delete/{SettlementId}")]
        public async Task<IActionResult> DeleteSettlemet(int SettlementId)
        {
            var response = await _settlementApplication.DeleteSettlement(SettlementId);
            return Ok(response);
        }

    }
}
