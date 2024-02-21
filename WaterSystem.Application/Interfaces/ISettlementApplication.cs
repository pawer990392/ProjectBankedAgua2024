using WaterSystem.Application.Commons.Bases;
using WaterSystem.Application.Dtos.Request;
using WaterSystem.Application.Dtos.Response;
using WaterSystem.Infrastructure.Commons.Bases.Request;
using WaterSystem.Infrastructure.Commons.Bases.Response;

namespace WaterSystem.Application.Interfaces
{
    public interface ISettlementApplication
    {
        //https://www.youtube.com/watch?v=5u1FIGGi8uA&list=PL-b0D_-Rciul_BHl6zR9B0K6fX2Hspfi8&index=8&ab_channel=amechatonet

        Task<BaseResponse<BaseEntityResponse<SettlementResponseDto>>> ListSettlmenties(BaseFiltersRequest filters);
        Task<BaseResponse<IEnumerable<SettlementSelectResponseDto>>> ListSelectSettlmenties();
        Task<BaseResponse<SettlementResponseDto>> SettlmentById (int SettlementId);
        Task<BaseResponse<bool>> RegisterSettlement(SettlementRequestDto requestDto);
        Task<BaseResponse<bool>> UpdateSettlement(int SettlementId, SettlementRequestDto requestDto);
        Task<BaseResponse<bool>> DeleteSettlement(int SettlementId);

    }
}
