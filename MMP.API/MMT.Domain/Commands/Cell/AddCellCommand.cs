﻿using MMT.Domain.Validations.Cell;

namespace MMT.Domain.Commands.Cell
{
    public class AddCellCommand : CellCommand
    {       

        public override bool IsValid()
        {
            ValidationResult = new CellCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
