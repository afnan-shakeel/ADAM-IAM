using System;
using System.Collections.Generic;

namespace Core.Exceptions
{
    public class ValidationException : Exception
    {
        public IDictionary<string, string> ValidationErrors { get; }

        public ValidationException(string message, IDictionary<string, string> validationErrors = null) : base(message)
        {
            ValidationErrors = validationErrors ?? new Dictionary<string, string>();
        }
    }
}
