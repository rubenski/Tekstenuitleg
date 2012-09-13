using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace CursusIndex.util.validation
{
    public class NameValidator : IValidator
    {

        private const string NameRegex = @"^([a-zA-Z0-9\s]{2,100})$";

        public FieldValidationResult Validate(object o)
        {
            if (!(o is string))
            {
                throw new ArgumentException("EmailValidator must receive a string");
            }

            var name = (string)o;

            if (!IsValidName(name))
            {
                return new FieldValidationResult(false, umbraco.library.GetDictionaryItem("InvalidNameMessage"));
            }

            return new FieldValidationResult(true, "");
        }

        private bool IsValidName(string name)
        {
            if (name != null && name.Trim().Length >= 2)
            {
                var re = new Regex(NameRegex);
                if (re.IsMatch(name))
                {
                    return (true);
                }
            }
            return false;
        }
    }


}