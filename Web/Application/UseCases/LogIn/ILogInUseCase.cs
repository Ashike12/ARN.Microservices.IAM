using Application.Abstraction.UseCase;
using ARN.Microservices.Infrastructure;

namespace Application.UseCases.LogIn
{
    public interface ILogInUseCase : IUseCase
    {
        Task<UseCaseResponse> Login(string email, string password);
    }
}
