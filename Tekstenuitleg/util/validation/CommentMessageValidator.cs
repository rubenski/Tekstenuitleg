using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using umbraco;

namespace CursusIndex.util.validation
{
    public class CommentMessageValidator : IValidator
    {
        public FieldValidationResult Validate(object o)
        {
            string message = (string) o;

            if (message.Trim().Length == 0)
            {
                return new FieldValidationResult(false, library.GetDictionaryItem("EmptyCommentMessage"));
            }

            return new FieldValidationResult(true, "");
        }
    }
}