using AutoMapper;
using WaterSystem.Application.Commons.Bases;
using WaterSystem.Application.Dtos.Request;
using WaterSystem.Application.Dtos.Response;
using WaterSystem.Application.Interfaces;
using WaterSystem.Application.Validators.Settlement;
using WaterSystem.Domain.Entities;
using WaterSystem.Infrastructure.Commons.Bases.Request;
using WaterSystem.Infrastructure.Commons.Bases.Response;
using WaterSystem.Infrastructure.Persistences.Interfaces;
using WaterSystem.Utilityes.Static;

namespace WaterSystem.Application.Services
{
    public class SettlementApplication : ISettlementApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly SettlementValidator _validator;

        public SettlementApplication(IUnitOfWork unitOfWork, IMapper mapper, SettlementValidator validator)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._validator = validator;
        }

        public async Task<BaseResponse<bool>> DeleteSettlement(int SettlementId)
        {
            var response = new BaseResponse<bool>();

            var settlementById = await SettlmentById(SettlementId);

            if(settlementById.Data is null)//si no hay nada
            {
                response.IsSuccess = false;
                response.Message = MessageStatic.MESSAGE_QUERY_EMPATY;
            }

             //var settlement = _mapper.Map<Settlement>(SettlementId);
             //settlement.IdSettlement = SettlementId;
             response.Data= await _unitOfWork.Settlement.DeleteEntityAsync(SettlementId);

            if (response.Data)
            {
                response.IsSuccess= true;
                response.Message = MessageStatic.MESSAGE_DELETE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = MessageStatic.MESSAGE_FALLED;
            }
            return response;
        }
        public async Task<BaseResponse<IEnumerable<SettlementSelectResponseDto>>> ListSelectSettlmenties()
        {
            var response = new BaseResponse<IEnumerable<SettlementSelectResponseDto>>();
            var settlementies = await _unitOfWork.Settlement.GetAlltAsync();

            if(settlementies is not null) {

                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<SettlementSelectResponseDto>>(settlementies);
                response.Message = MessageStatic.MESSAGE_QUERY;
              }
            else
            {
                response.IsSuccess = false;
                response.Message = MessageStatic.MESSAGE_QUERY_EMPATY;
            }
            return response;

        }

        public async Task<BaseResponse<BaseEntityResponse<SettlementResponseDto>>> ListSettlmenties(BaseFiltersRequest filters)
        {
            var response = new BaseResponse<BaseEntityResponse<SettlementResponseDto>>();

            var settlmetenties = await _unitOfWork.Settlement.ListSettlementies(filters);

            if(settlmetenties!=null) //validando que no sea null
            {
                response.IsSuccess=true;
                //que necesitamos mapear que este recibe una clases y entonces que vamos a mapear que viene de nestro reposotiorio
                response.Data =_mapper.Map<BaseEntityResponse<SettlementResponseDto>>(settlmetenties);
                response.Message = MessageStatic.MESSAGE_QUERY;
            }
            else
            { 
                response.IsSuccess = false;
                response.Message = MessageStatic.MESSAGE_QUERY_EMPATY;
            }
            return response;
        }
        
        public async Task<BaseResponse<bool>> RegisterSettlement(SettlementRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            var validactionResult = await _validator.ValidateAsync(requestDto);

            //proceso de validation
            if(!validactionResult.IsValid)
            {
                response.IsSuccess = false;
                response.Message = MessageStatic.MESSAGE_VALIDATE;
                response.Errors=validactionResult.Errors;
                return response;
            }
            //consulatr mi metodo
            var newSettlment = _mapper.Map<Settlement>(requestDto);
            response.Data = await _unitOfWork.Settlement.RegisterEntityAsync(newSettlment);

            if(response.Data)
            {
                response.IsSuccess = true;
                response.Message = MessageStatic.MESSAGE_SAVE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = MessageStatic.MESSAGE_FALLED;
            }
            return response;
            //var settlement = await _unitOfWork.Settlement.RegisterSettlemet(requestDto);
        }

        public async Task<BaseResponse<SettlementResponseDto>> SettlmentById(int SettlementId)
        {
            var response = new  BaseResponse<SettlementResponseDto>();
            var settlmetent = await _unitOfWork.Settlement.GetByIdAsync(SettlementId);

            if(settlmetent!=null)
            {
                response.IsSuccess=true;
                response.Data = _mapper.Map<SettlementResponseDto>(settlmetent);
                response.Message = MessageStatic.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = MessageStatic.MESSAGE_QUERY_EMPATY;
            }
            return response;
        }
        public async Task<BaseResponse<bool>> UpdateSettlement(int SettlementId, SettlementRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            //primero necesitamos traer el id de la entidad
            var settlementId = await SettlmentById(SettlementId);

            if (settlementId.Data is null)//en caso de que no encotro nada
            {
                
                response.IsSuccess = false;
                response.Message = MessageStatic.MESSAGE_QUERY_EMPATY;
            }
            //mapelamos nuestra request a a la entidad correspodiente
            var settlement = _mapper.Map<Settlement>(requestDto);
            settlement.Id = SettlementId;
            response.Data = await _unitOfWork.Settlement.UpdateEntityAsync(settlement);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = MessageStatic.MESSAGE_UPDATE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = MessageStatic.MESSAGE_FALLED;
            }
            return response;
        }
    }
}
