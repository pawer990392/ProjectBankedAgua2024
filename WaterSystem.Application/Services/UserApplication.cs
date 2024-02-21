using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WaterSystem.Application.Commons.Bases;
using WaterSystem.Application.Dtos.Request;
using WaterSystem.Application.Interfaces;
using WaterSystem.Application.Validators.User;
using WaterSystem.Domain.Entities;
using WaterSystem.Infrastructure.Persistences.Interfaces;
using WaterSystem.Utilityes.Static;
using BC = BCrypt.Net.BCrypt;

namespace WaterSystem.Application.Services
{
    public class UserApplication : IUserApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserValidator _userValidator;
        private readonly IConfiguration _configuration;

        //injectamos las depedencia 
        public UserApplication(IUnitOfWork unitOfWork, IMapper mapper, UserValidator userValidator, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userValidator = userValidator;
            _configuration = configuration;
        }

        public async Task<BaseResponse<string>> GenereToken(TokenRequestDto requestDto)
        {
            var response = new BaseResponse<string>();

            var account = await _unitOfWork.User.AccountByUserName(requestDto.UserName!);

            if(account!=null)
            {
                if (BC.Verify(requestDto.Password, account.Password))
                {
                    response.IsSuccess=true;
                    response.Data= GenerateToken(account);
                    response.Message = MessageStatic.MESSAGE_TOKEN;
                    return response;
                }
            }
            else
            {
                response.IsSuccess=false;
                response.Message = MessageStatic.MESSAGE_USERNOTEXIT;
            }
            return response;

        }

        public async Task<BaseResponse<bool>> RegisterUser(UserRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            var validationResult = await _userValidator.ValidateAsync(requestDto);
            
            if(!validationResult.IsValid) {

                response.IsSuccess = false;
                response.Message= MessageStatic.MESSAGE_VALIDATE;
                response.Errors = validationResult.Errors;
                return response;
            }
           var newUser = _mapper.Map<User>(requestDto);
           newUser.Password= BC.HashPassword(newUser.Password);
           response.Data= await _unitOfWork.User.RegisterEntityAsync(newUser);

            if (response.Data)
            {
                response.IsSuccess= true;
                response.Message= MessageStatic.MESSAGE_SAVE;
            }
            else
            {
                response.IsSuccess= false;
                response.Message = MessageStatic.MESSAGE_FALLED;
            }
            return response;

        }

        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]!));
            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);//tipo de gaseo
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId,user.Email),
                new Claim(JwtRegisteredClaimNames.FamilyName,user.UserName),
                new Claim(JwtRegisteredClaimNames.GivenName,user.Email),
                new Claim(JwtRegisteredClaimNames.UniqueName,user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,Guid.NewGuid().ToString(),ClaimValueTypes.Integer64)

            };
            var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Issuer"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:ExpireTime"]!)),
                    notBefore: DateTime.UtcNow,
                    signingCredentials: credential);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
