using FluentValidation.Results;

namespace Core.Middleware.Exception
{
    public class ValidationErrorDetails : ErrorDetails
    {
        public IEnumerable<ValidationFailure> ValidationErrors { get; set; }
    }


}
