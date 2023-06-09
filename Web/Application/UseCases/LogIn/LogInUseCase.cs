
using ARN.Microservices.Infrastructure;

namespace Application.UseCases.LogIn
{
    public class LogInUseCase : ILogInUseCase
    {
        public async Task<UseCaseResponse> Login(string email, string password)
        {
            return UseCaseResponseHandler.HandleSuccess(false);
        }
    }
}
