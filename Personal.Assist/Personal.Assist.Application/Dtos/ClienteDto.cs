using Personal.Assist.Cliente.Domain.Interfaces.Dtos;
using FluentValidation;

namespace Personal.Assist.Cliente.Application.Dtos
{
    public class ClienteDto: IClienteDto
    {
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
        public int Idade { get; set; }
        public void Validate()
        {
            var validateResult = new CategoriaDtoValidation().Validate(this);

            if (!validateResult.IsValid)
                throw new ArgumentException(string.Join(" e ", validateResult.Errors.Select(x => x.ErrorMessage)));
        }
    }

    internal class CategoriaDtoValidation : AbstractValidator<ClienteDto>
    {
        public CategoriaDtoValidation()
        {
            RuleFor(x => x.Nome)
                .MinimumLength(5).WithMessage(x => $"O campo {nameof(x.Nome)}, deve ter no minimo 5 caracteres")
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.Nome)}, não pode ser vazio");
            
            RuleFor(x => x.SobreNome)
                .MinimumLength(5).WithMessage(x => $"O campo {nameof(x.SobreNome)}, deve ter no minimo 5 caracteres")
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.SobreNome)}, não pode ser vazio");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage(x => $"O {nameof(x.Email)}, não é valido")
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.Equals)}, não pode ser vazio");
        }
    }
}
