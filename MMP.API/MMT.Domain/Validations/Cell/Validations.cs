using FluentValidation;
using MMT.Domain.Commands.Cell;

namespace MMT.Domain.Validations.Cell
{
    public abstract class Validations<T> : AbstractValidator<T> where T : CellCommand
    {
        protected void ValidateCell()
        {
            RuleFor(c => c.CellName)
                 .NotNull().WithMessage("CellName Cannot be null")
                 .NotEmpty().WithMessage("Please ensure you have Entry CellName");
        }
    }
}
