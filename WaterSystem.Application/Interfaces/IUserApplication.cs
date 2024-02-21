using WaterSystem.Application.Commons.Bases;
using WaterSystem.Application.Dtos.Request;

namespace WaterSystem.Application.Interfaces
{
    public interface IUserApplication
    {
        //crear los meotdos que necesitamos
        Task<BaseResponse<bool>> RegisterUser(UserRequestDto requestDto);
        Task<BaseResponse<string>> GenereToken(TokenRequestDto requestDto);

    }
}
