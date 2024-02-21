using FluentValidation;
using WaterSystem.Application.Dtos.Request;

namespace WaterSystem.Application.Validators.Settlement
{
    public class SettlementValidator : AbstractValidator<SettlementRequestDto>
    {
        public SettlementValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("El campo Nombre No puede ser Nulo")
                                .NotEmpty().WithMessage("El campo Nombre No se puede ser Vacio");

        }
    }
}
