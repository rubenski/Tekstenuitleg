using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CursusIndex.util.validation
{
    public interface IValidator
    {
        FieldValidationResult Validate(object o);
    }
}
