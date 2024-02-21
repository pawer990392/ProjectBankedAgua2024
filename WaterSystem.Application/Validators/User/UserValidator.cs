using FluentValidation;
using WaterSystem.Application.Dtos.Request;
using System.Text.RegularExpressions;


namespace WaterSystem.Application.Validators.User
{
    public class UserValidator: AbstractValidator<UserRequestDto>
    {
        public UserValidator()
        {
            RuleFor(x=> x.UserName).NotEmpty().WithMessage("No ha indicado el nombre de usuario.")
                                        .NotNull().WithMessage("El campo Nombre No puede ser Nulo")
            .Matches(@"^[a-zA-Z0-9_?-]{8,18}$").WithMessage("El Campo UserName No Cumple los requerimientos");

            RuleFor(x => x.Password).NotEmpty().WithMessage("No ha indicado el Password de usuario.")
                                        .NotNull().WithMessage("El campo Password No puede ser Nulo")
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,15}$")
            .WithMessage("El Password debe tener Minimo 8 caracteres,Maximo 15,Al menos una letra mayúscula,Al menos una letra minucula," +
            "Al menos un dígito,No espacios en blanco,Al menos 1 caracter especial");

            RuleFor(x => x.Name).NotEmpty().WithMessage("No ha indicado el nombre de usuario.")
                                     .NotNull().WithMessage("El campo Nombre No puede ser Nulo")
             .Matches(@"^[ a-zA-ZñÑáéíóúÁÉÍÓÚ]+$").WithMessage("El Campo Nombre No Cumple los requerimientos");

            RuleFor(x => x.Phone).NotEmpty().WithMessage("No ha indicado el Telefono de usuario.")
                                     .NotNull().WithMessage("El campo Telefono No puede ser Nulo")
             .Matches(@"^[0-9]{10}$").WithMessage("El Campo Telefono No Cumple los requerimientos");
        }

    }

}

