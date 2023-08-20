using Product.Api.ViewModels;
using MediatR;

namespace Product.Api.Application.Queries.Users;

public class RefreshTokenQuery : IRequest<AuthViewModel.GetTokenOutput>
{
    public string RefreshToken { get; set; }
}