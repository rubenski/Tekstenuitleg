using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace CursusIndex.util.validation
{
    public class EmailValidator : IValidator
    {
        private const string EmailRegex =
            @"^(?("")(""[^""]+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$";

        public FieldValidationResult Validate(object o)
        {
            if (!(o is string))
            {
                throw new ArgumentException("EmailValidator must receive a string");
            }

            var email = (string)o;

            if (!IsEmail(email))
            {
                return new FieldValidationResult(false, umbraco.library.GetDictionaryItem("InvalidEmailMessage"));
            }

            return new FieldValidationResult(true, "");
        }

        private bool IsEmail(string email)
        {
            if (email != null && email.Trim().Length >= 6)
            {
                var re = new Regex(EmailRegex);
                if (re.IsMatch(email))
                {
                    return (true);
                }
            }
            return false;
        }
    }
}