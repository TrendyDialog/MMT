using MMT.Domain.Commands.Cell;

namespace MMT.Domain.Validations.Cell
{
    public class CellCommandValidation : Validations<CellCommand>
    {
        public CellCommandValidation()
        {
            ValidateCell();
        }
    }
}
