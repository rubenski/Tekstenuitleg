using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CursusIndex.util.validation
{
    public class FieldValidationResult
    {
        public string Message;
        public bool Valid;

        public FieldValidationResult(bool isValid, string message)
        {
            Message = message;
            Valid = isValid;
        }
    }
}