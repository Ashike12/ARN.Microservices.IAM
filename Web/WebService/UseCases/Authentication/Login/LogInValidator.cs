using FluentValidation;

namespace ARN.Microservices.IAM.UseCases.Authentication.Login
{
    public class LogInValidator : AbstractValidator<LogInRequest>
    {
        public LogInValidator()
        {
            RuleFor(x => x.Email).NotNull().NotEmpty();
            RuleFor(x => x.Password).NotNull().NotEmpty();
        }
    }
}
