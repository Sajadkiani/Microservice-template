using System.Collections.Generic;
using Product.Api.ViewModels;
using MediatR;

namespace Product.Api.Application.Queries.Users;

public class GetUserRolesQuery : IRequest<IEnumerable<AuthViewModel>>
{
    public GetUserRolesQuery(int userId)
    {
        UserId = userId;
    }

    public int UserId { get; }
}